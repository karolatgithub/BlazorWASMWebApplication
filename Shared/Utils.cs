namespace BlazorWASMWebApplication.Shared
{
    public class Utils
    {
        public static string ENCODE_TOKEN_TO_BASE_64(string token)
        {
            try
            {
                return Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(token));
            }
            catch (Exception ex)
            {
                throw new Exception("Error in base64Encode" + ex.Message);
            }
        }

        public static string DECODE_FROM_BASE_64(string encodedData)
        {
            System.Text.Decoder utf8Decode = new System.Text.UTF8Encoding().GetDecoder();
            byte[] todecode_byte = Convert.FromBase64String(encodedData);
            char[] decoded_char = new char[utf8Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length)];
            utf8Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
            return new String(decoded_char);
        }

        public static readonly string DATE_TIME_TO_STRING_FORMAT = "yyyy-MM-dd HH:mm:ss";
    }
}
