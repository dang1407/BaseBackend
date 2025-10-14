namespace BaseBackend.Common
{
    public static class SafeAPI
    {
        public static List<string> WhiteList = new List<string>()
        {
            "Authenticate/login",
            "/api/v1/Authenticate/login",
            "/api/v1/Authenticate/GetEncryptData",
            "/swagger",
            "/swagger/index.html",
            "/swagger/v1/swagger.json",
            "/swagger/swagger-ui.css",
            "/swagger/swagger-ui-bundle.js",
            "/swagger/swagger-ui-standalone-preset.js"
        };
    }
}
