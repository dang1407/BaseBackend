using BaseBackend.Domain;
using Dapper;
using System.Data;

namespace BaseBackend.Infrastructure
{
    public class adm_userRepository : BaseRepository
    {
        public adm_user GetById(int id)
        {
            var findedItem = FindById<adm_user>(id);
            if (findedItem == null) throw new NotFoundException();
            return findedItem;
        }

        public List<adm_user> GetPaging(adm_userFilter? filter, PagingInfo pagingInfo)
        {
            string query = @"
select 
au.user_id,
au.name,
au.username, 
au.code,
au.version,
au.dob,
au.gender,
au.email,
au.authencation_type,
au.created_by,
au.created_time,
au.updated_by,
au.updated_time,
au.notes,
au.number_of_fail,
au.phone,
au.status
from adm_user au
where deleted = @is_not_deleted
";
            if (!string.IsNullOrWhiteSpace(filter.username))
            {
                query += " and username = @username ";
            }

            if (!string.IsNullOrWhiteSpace(filter.name))
            {
                query += " and name ilike @name";
            }

            if (filter.dob_from.HasValue)
            {
                query += " and dob >= @dob_from";
            }
            query += " order by name, user_id limit @page_size offset @offset";
            DynamicParameters param = new DynamicParameters();
            // Filter
            param.Add("@username", filter.username);
            param.Add("@name", BuildLikeFilter(filter.name));
            param.Add("@dob_from", filter.dob_from);
            // Hệ thống
            param.Add("@offset", pagingInfo.PageIndex * pagingInfo.PageSize);
            param.Add("@page_size", pagingInfo.PageSize);
            param.Add("@is_not_deleted", SharedResource.IsNotDeleteInt);
            using UnitOfWork unitOfWork = new UnitOfWork();
            var result = unitOfWork.Connection.Query<adm_user>(query, param).ToList();
            // Loại bỏ các trường thông tin nhạy cảm 
            result.ForEach(user => {
                user.password = null;
                user.password_salt = null;
            });
            return result;
        }

        public adm_user? GetUserByUserName(string username)
        {
            string query = @"
select user_id, username, password, password_salt
from adm_user 
where username = @username and deleted = @is_not_deleted
";
            DynamicParameters param = new DynamicParameters();
            param.Add("@username", username);
            param.Add("@is_not_deleted", SharedResource.IsNotDeleteInt);
            using UnitOfWork unitOfWork = new UnitOfWork();
            return unitOfWork.Connection.QueryFirstOrDefault<adm_user>(query, param);
        }

        public List<AdmRole> GetRolesOfEmployee(int? userID)
        {
            string query = @"
select rol.role_id, rol.code, rol.name
from adm_user emp
inner join adm_user_role emprole on emprole.user_id = emp.user_id
inner join adm_role rol on rol.role_id = emprole.role_id 
where rol.deleted = 0
    and rol.is_active = true
    and emp.user_id = @user_id
";
            DynamicParameters param = new DynamicParameters();
            param.Add("@user_id", userID);
            using UnitOfWork unitOfWork = new();
            var result = unitOfWork.Connection.Query<AdmRole>(query, param);
            return result.ToList();
        }

        public List<FunctionRight> GetRightsOfEmployee(int userId, List<int> lstRole)
        {
            string cmdText = string.Format(@"
select fea.feature_id, fuc.function_id, fuc.code as function_code, ff.rule_id, ff.url as url
from adm_user emp
inner join adm_right rig on rig.user_id = emp.user_id
inner join adm_feature_function ff on ff.feature_id = rig.feature_id 
      and ff.function_id = rig.function_id 
inner join adm_function fuc on fuc.function_id = ff.function_id 
inner join adm_feature fea on fea.feature_id = ff.feature_id 
      and fea.deleted = 0
where emp.deleted = 0 
	and emp.user_id = @user_id

union

select fea.feature_id, fuc.function_id, fuc.code as function_code, ff.rule_id, ff.url as url
from adm_role rol
inner join adm_right rig on rig.role_id = rol.role_id
inner join adm_feature_function ff on ff.feature_id = rig.feature_id 
    and ff.function_id = rig.function_id 
inner join adm_function fuc on fuc.function_id = ff.function_id
inner join adm_feature fea on fea.feature_id = ff.feature_id
where rol.Role_ID in ({0})", BuildInCondition(lstRole));
            DynamicParameters param = new DynamicParameters();
            param.Add("@user_id", userId);
        using UnitOfWork unitOfWork = new UnitOfWork();
            var result = unitOfWork.Connection.Query<FunctionRight>(cmdText, param);
            return result.ToList();
        }
    }
}
