namespace smert.Models.ssl {
    public class ssl_cert {
        public ssl_cert() { }

        private string certificate {get; set;} = $"-----BEGIN CERTIFICATE-----"+
                                                    $"MIIDbzCCAlegAwIBAgIEBMagIDANBgkqhkiG9w0BAQsFADCBhzEtMCsGA1UELhMk"+
                                                    $"MDZlYzMyYTUtNjA3YS00ZTJkLTgzMTgtMDUzNmI2ZWFmNjg0MTMwMQYDVQQDEypH"+
                                                    $"b29nbGUgQ2xvdWQgU1FMIENsaWVudCBDQSBkZXYtYWNjZXNzLWNlcnQxFDASBgNV"+
                                                    $"BAoTC0dvb2dsZSwgSW5jMQswCQYDVQQGEwJVUzAeFw0yMTExMTcxNjI5MjNaFw0z"+
                                                    $"MTExMTUxNjMwMjNaMD0xGDAWBgNVBAMTD2Rldi1hY2Nlc3MtY2VydDEUMBIGA1UE"+
                                                    $"ChMLR29vZ2xlLCBJbmMxCzAJBgNVBAYTAlVTMIIBIjANBgkqhkiG9w0BAQEFAAOC"+
                                                    $"AQ8AMIIBCgKCAQEAgiqWP8Jwd/Pd22q1sOMY16JiWVsCZTt80irBWEzsMnugn4ij"+
                                                    $"ckVLJ2gjnPl0pSAXlbKKDC/7fAwumFr9GrZ83vU2WFcNKb/YcU8xRAQff/TiXTeu"+
                                                    $"saxCXyBTOf3xS1ZF23ezaF7V6nLm4/xHwNrWE3V+tjXY41xhF+4vB4rDC3r9aRoF"+
                                                    $"tPMlnFqC9wdx6ayFi2u2mBNg7bHY0q6bmGasTu20HltP4MHz2iOecieX2qyNkFeS"+
                                                    $"JGrY25TSl+3+HwUAoTp/oouKvQ+KkXAQKXUeGTMVkI1dREJor6C8imQ2oBAY5GH/"+
                                                    $"CrKZZMedUt89RP3ZqeSNNdn8eoNhT4bO6TmW4QIDAQABoywwKjAJBgNVHRMEAjAA"+
                                                    $"MB0GA1UdEQQWMBSBEnBmZWluc29uQGdtYWlsLmNvbTANBgkqhkiG9w0BAQsFAAOC"+
                                                    $"AQEAElxOKEbSr3GQXdc7wUD+Dm9NpsGJRrAlMZtFcmX1OrwllVEixf/qSvVvWUfd"+
                                                    $"0FXGhQ4kt/cjmtYNqz5gMJ4uslqa32DqW3Q8//MiRxS36pDifzuRYVcA0PLYvgvB"+
                                                    $"g31IjjgXTcS6gMHsxAhNezERlq7crxZifFhqG6ZLJu7JWMI6TSjVZPwl/0Scajjx"+
                                                    $"m/Gp1wlGZqtodLOUw4q+o2ZQUwzKOuLy0lm5vxsJwH0aFthZH9ks7LcNbjgMKE87"+
                                                    $"Yp7EhXpnhghHRvpZi2oV6Sqkmzrh6ih1rQPy6gD0Argiq4z/NnzUMD9QBx8s40Nw"+
                                                    $"W8CY4L17fDhLeEzahEjwPBQO5w=="+
                                                    $"-----END CERTIFICATE-----";
        public string getCertificate() { return certificate; }
    }
}