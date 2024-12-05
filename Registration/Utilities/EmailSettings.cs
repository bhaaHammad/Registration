﻿namespace Registration.Utilities
{
    public class EmailSettings
    {
        public string? FromName { get; set; }
        public string? FromEmail { get; set; }
        public string? SmtpServer { get; set; }
        public int SmtpPort { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
    }
}
