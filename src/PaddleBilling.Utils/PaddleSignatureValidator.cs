using Microsoft.Extensions.Logging;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace PaddleBilling.Utils
{
    public interface IPaddleSignatureValidator
    {
        bool ValidateSignature(string signature, string payload, string verificationKey, int maxTimestampAgeInSeconds);
    }

    public class PaddleSignatureValidator(ILogger<PaddleSignatureValidator> logger) : IPaddleSignatureValidator
    {
        public bool ValidateSignature(string signature, string payload, string verificationKey, int maxTimestampAgeInSeconds)
        {
            if (string.IsNullOrWhiteSpace(signature) || string.IsNullOrWhiteSpace(payload) || string.IsNullOrWhiteSpace(verificationKey))
            {
                logger.LogWarning("Signature, payload, or localKey is null or empty.");
                return false;
            }

            var (ts, h1) = ExtractSignatureParts(signature);
            if (ts == null || h1 == null)
            {
                logger.LogWarning("Invalid signature format.");
                return false;
            }

            if (!IsFreshTimestamp(ts, maxTimestampAgeInSeconds))
            {
                logger.LogWarning("Old timestamp age in signature.");
                return false;
            }

            var signedPayload = $"{ts}:{payload}";

            using var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(verificationKey));
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(signedPayload));
            var receivedHash = Convert.FromHexString(h1);

            if (!CryptographicOperations.FixedTimeEquals(receivedHash, computedHash))
            {
                logger.LogWarning("Signature mismatch.");
                return false;
            }

            return true;
        }

        private bool IsFreshTimestamp(string ts, int maxTimestampAgeInSeconds)
        {
            var currentTimestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            if (!long.TryParse(ts, out var tsValue))
            {
                logger.LogWarning("Invalid timestamp in signature.");
                return false;
            }

            if (Math.Abs(currentTimestamp - tsValue) > maxTimestampAgeInSeconds)
            {
                logger.LogWarning("Timestamp too old or too far in the future.");
                return false;
            }

            return true;
        }

        private static (string ts, string h1) ExtractSignatureParts(string signature)
        {
            var match = Regex.Match(signature, @"^ts=(\d+);h1=([\da-fA-F]+)$");
            if (!match.Success || match.Groups.Count != 3)
            {
                return (null, null);
            }

            return (match.Groups[1].Value, match.Groups[2].Value);
        }
    }
}