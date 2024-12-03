using Mtf.HardwareKey.Exceptions;
using System.Collections.Generic;

namespace Mtf.HardwareKey.Models
{
    public sealed class HardwareKeyDeveloper
    {
        public static readonly SortedList<ushort, HardwareKeyDeveloper> Values = new SortedList<ushort, HardwareKeyDeveloper>();

        private static readonly Dictionary<ushort, PasswordStorage> additionalKeyData = new Dictionary<ushort, PasswordStorage>()
        {
        };

        public static readonly HardwareKeyDeveloper Test1 = new HardwareKeyDeveloper(2345);
        public static readonly HardwareKeyDeveloper Test2 = new HardwareKeyDeveloper(3456);


        private readonly ushort developerId;

        private HardwareKeyDeveloper(ushort developerId)
        {
            this.developerId = developerId;
            Values.Add(developerId, this);
            var secrets = GetWritePasswords();
            WritePassword = secrets.WritePassword;
            OverwritePassword1 = secrets.OverwritePassword1;
            OverwritePassword2 = secrets.OverwritePassword2;
        }

        public ushort WritePassword { get; }

        public ushort OverwritePassword1 { get; }

        public ushort OverwritePassword2 { get; }

        public static implicit operator HardwareKeyDeveloper(ushort developerId)
        {
            return Values[developerId];
        }

        public static implicit operator ushort(HardwareKeyDeveloper hardwareKeyType)
        {
            return hardwareKeyType.developerId;
        }

        private PasswordStorage GetWritePasswords()
        {
            return additionalKeyData.TryGetValue(developerId, out var secrets) ? secrets
                : throw new NoSecretsFoundException($"DeveloperId: {developerId} not present in {nameof(additionalKeyData)}");
        }
    }
}
