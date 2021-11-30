namespace smert.Models.ssl {
    public class ssl_ca {

        public ssl_ca() { }

        private string certificate {get; set;} = $"-----BEGIN CERTIFICATE-----"+
                                                    $"MIIDfzCCAmegAwIBAgIBADANBgkqhkiG9w0BAQsFADB3MS0wKwYDVQQuEyQwODgy"+
                                                    $"YmUwOC0zOWEzLTQ2ZTItYjMxMS00ZDI0YTgwZjRjZmYxIzAhBgNVBAMTGkdvb2ds"+
                                                    $"ZSBDbG91ZCBTUUwgU2VydmVyIENBMRQwEgYDVQQKEwtHb29nbGUsIEluYzELMAkG"+
                                                    $"A1UEBhMCVVMwHhcNMjExMTExMDM0NTAzWhcNMzExMTA5MDM0NjAzWjB3MS0wKwYD"+
                                                    $"VQQuEyQwODgyYmUwOC0zOWEzLTQ2ZTItYjMxMS00ZDI0YTgwZjRjZmYxIzAhBgNV"+
                                                    $"BAMTGkdvb2dsZSBDbG91ZCBTUUwgU2VydmVyIENBMRQwEgYDVQQKEwtHb29nbGUs"+
                                                    $"IEluYzELMAkGA1UEBhMCVVMwggEiMA0GCSqGSIb3DQEBAQUAA4IBDwAwggEKAoIB"+
                                                    $"AQCfhMiL35kT6ZnaufG/Aa44DzUNohIeotRCPu0pfnp2xDqa0Dd7/yqH/DmePNjx"+
                                                    $"TZDvtzRUwleFQEXzLpw7DF2iOXK8e75kz+85xAonQ33e8jCrOhK8berYCHWTXEHC"+
                                                    $"6YyoIOpsr2NjLF9nV4rrAKl5+A1Um9W66NobvfUkUx5dQpDwoWW2Whlaisekg9Mx"+
                                                    $"6b8l67aSnnKRI1GO+p5dF3+YEt/ynT6KJy+P2CRXjxTgOydRZ++EA3wA95nzR9Cx"+
                                                    $"weoSnDtWhV26EjV+QR3c29J5EefcpCjvS0kZfpU6Mx/VH0IR/zO6eYmzw2nqOKpl"+
                                                    $"UWt3QjUcD/STrn0zDi6lr+2hAgMBAAGjFjAUMBIGA1UdEwEB/wQIMAYBAf8CAQAw"+
                                                    $"DQYJKoZIhvcNAQELBQADggEBAFWShkO702I5oXvLxqnoM53++UXajrByseABSv2i"+
                                                    $"NoTt7LvAhTrGx6f0TrcdnZecgmNG9QKq2VELYTekTu6Vxyivw11EJtrq9XyMV85p"+
                                                    $"pHyvoPlKZM9KqCpVa/+XpMU8Syo0uyMKVqSsSV8ABLEUnB7WpGp24eq8A/lxaAkd"+
                                                    $"W149LnoSHMkm47rsUo6QCPRKKY3eO1XfchjXGiYysfc/2USy/mLxIM/rJpVSszHo"+
                                                    $"rS5EklIZWQpirt2E7+oOVz3tIEJ8Hhhgm07UQtEGtOxSGrPkDYIk80vtpCREch3F"+
                                                    $"UMGs5zabIG2laSWwycqNEY9zIwTEsom7tgT8gtpXQTmscaU="+
                                                    $"-----END CERTIFICATE-----";

        public string getCertificate() { return certificate; }
    }
}