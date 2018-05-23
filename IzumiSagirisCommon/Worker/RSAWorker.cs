using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace IzumiSagirisCommon.Worker
{
    public static class RSAWorker
    {
        private static string PublicKey = @"<RSAKeyValue>
  <Modulus>8Yvf/LjXRhCuOREk2CuSYvbD/RadwJ4sjHREIpQVKwkTlG3BtRgpnaMcoeLAesmwvpBWnqK4hBkYLxhRj+NEKnlGrJ+LkNMnZr0/4CMuulZFAnx7iQYaSq7Eh7kBKGLofc05CjZguYpnPNxHIv4VNx+a9tIh+hnhjrmkJLUm3l0=</Modulus>
  <Exponent>AQAB</Exponent>
</RSAKeyValue>";

        private static string PrivateKey = @"<RSAKeyValue>
  <Modulus>8Yvf/LjXRhCuOREk2CuSYvbD/RadwJ4sjHREIpQVKwkTlG3BtRgpnaMcoeLAesmwvpBWnqK4hBkYLxhRj+NEKnlGrJ+LkNMnZr0/4CMuulZFAnx7iQYaSq7Eh7kBKGLofc05CjZguYpnPNxHIv4VNx+a9tIh+hnhjrmkJLUm3l0=</Modulus>
  <Exponent>AQAB</Exponent>
  <P>/xAaa/4dtDxcEAk5koSZBPjuxqvKJikpwLA1nCm3xxAUMDVxSwQyr+SHFaCnBN9kqaNkQCY6kDCfJXFWPOj0Bw==</P>
  <Q>8m8PFVA4sO0oEKMVQxt+ivDTHFuk/W154UL3IgC9Y6bzlvYewXZSzZHmxZXXM1lFtwoYG/k+focXBITsiJepew==</Q>
  <DP>ONVSvdt6rO2CKgSUMoSfQA9jzRr8STKE3i2lVG2rSIzZosBVxTxjOvQ18WjBroFEgdQpg23BQN3EqGgvqhTSQw==</DP>
  <DQ>gfp7SsEM9AbioTDemHEoQlPly+FyrxE/9D8UAt4ErGX5WamxSaYntOGRqcOxcm1djEpULMNP90R0Wc7uhjlR+w==</DQ>
  <InverseQ>C0eBsp2iMOxWwKo+EzkHOP0H+YOitUVgjekGXmSt9a3TvikQNaJ5ATlqKsZaMGsnB6UIHei+kUaCusVX0HgQ2A==</InverseQ>
  <D>tPYxEfo9Nb3LeO+SJe3G1yO+w37NIwCdqYB1h15f2YUMSThNVmpKy1HnYpUp1RQDuVETw/duu3C9gJL8kAsZBjBrVZ0zC/JZsgvSNprfUK3Asc4FgFsGfQGKW1nvvgdMbvqr4ClB0R8czkki+f9Oc5ea/RMqXxlI+XjzMYDEknU=</D>
</RSAKeyValue>";

        public static string RsaEncrypt(string rawInput)
        {
            string publicKey = PublicKey;

            if (string.IsNullOrEmpty(rawInput))
            {
                return string.Empty;
            }

            if (string.IsNullOrWhiteSpace(publicKey))
            {
                throw new ArgumentException("Invalid Public Key");
            }

            using (var rsaProvider = new RSACryptoServiceProvider())
            {
                var inputBytes = Encoding.UTF8.GetBytes(rawInput);//有含义的字符串转化为字节流
                rsaProvider.FromXmlString(publicKey);//载入公钥
                int bufferSize = (rsaProvider.KeySize / 8) - 11;//单块最大长度
                var buffer = new byte[bufferSize];
                using (MemoryStream inputStream = new MemoryStream(inputBytes),
                     outputStream = new MemoryStream())
                {
                    while (true)
                    { //分段加密
                        int readSize = inputStream.Read(buffer, 0, bufferSize);
                        if (readSize <= 0)
                        {
                            break;
                        }

                        var temp = new byte[readSize];
                        Array.Copy(buffer, 0, temp, 0, readSize);
                        var encryptedBytes = rsaProvider.Encrypt(temp, false);
                        outputStream.Write(encryptedBytes, 0, encryptedBytes.Length);
                    }
                    return Convert.ToBase64String(outputStream.ToArray());//转化为字节流方便传输
                }
            }
        }

        public static string RsaDecrypt(string encryptedInput)
        {
            string privateKey = PrivateKey;
            if (string.IsNullOrEmpty(encryptedInput))
            {
                return string.Empty;
            }

            if (string.IsNullOrWhiteSpace(privateKey))
            {
                throw new ArgumentException("Invalid Private Key");
            }

            using (var rsaProvider = new RSACryptoServiceProvider())
            {
                var inputBytes = Convert.FromBase64String(encryptedInput);
                rsaProvider.FromXmlString(privateKey);
                int bufferSize = rsaProvider.KeySize / 8;
                var buffer = new byte[bufferSize];
                using (MemoryStream inputStream = new MemoryStream(inputBytes),
                     outputStream = new MemoryStream())
                {
                    while (true)
                    {
                        int readSize = inputStream.Read(buffer, 0, bufferSize);
                        if (readSize <= 0)
                        {
                            break;
                        }

                        var temp = new byte[readSize];
                        Array.Copy(buffer, 0, temp, 0, readSize);
                        var rawBytes = rsaProvider.Decrypt(temp, false);
                        outputStream.Write(rawBytes, 0, rawBytes.Length);
                    }
                    return Encoding.UTF8.GetString(outputStream.ToArray());
                }
            }
        }

    }
}
