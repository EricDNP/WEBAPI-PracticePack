using Amazon.Lambda.APIGatewayEvents;
using HttpMultipartParser;

namespace Serverless.Helper
{
    public static class MultipartBinder
    {
        public static T Bind<T>(IMultipartFormDataParser parser) where T : new()
        {
            var instance = new T();
            var props = typeof(T).GetProperties();

            foreach ( var prop in props )
            {
                var value = parser.GetParameterValue(prop.Name);
                if (value == null) continue;

                var converted = Convert.ChangeType(value, prop.PropertyType);
                prop.SetValue(instance, converted);
            }

            return instance;
        }
    }
}
