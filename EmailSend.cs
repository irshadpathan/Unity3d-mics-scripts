using UnityEngine;
using System.Collections;
using System;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;



// Check Gmail SMTS Server setting or your server setting

public class EmailSend : MonoBehaviour {
  
    void Start()
    {  
        MailMessage mail = new MailMessage();

        mail.From = new MailAddress("you@gmail.com"); // sender
        mail.To.Add("your@gmail.com"); // receiver
        mail.Subject = "Hello"; // header
        mail.Body = "Test"; // your message

        SmtpClient smtpServer = new SmtpClient("smtp.gmail.com"); // gmail SMTP
        smtpServer.Port = 587; // used port for gmail SMTP with SSL
        // your valid account informations
        smtpServer.Credentials = new System.Net.NetworkCredential("your@gmail.com", "password") as ICredentialsByHost;
        smtpServer.EnableSsl = true; // SSL option
        // check relation between sender and SMTP
        ServicePointManager.ServerCertificateValidationCallback =
            delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
            { return true; };
        // send mail
        smtpServer.Send(mail);
        Debug.Log("success"); // done
    }
}