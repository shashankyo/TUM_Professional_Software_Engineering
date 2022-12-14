namespace ProSE
{
    public class MailService
    {
        public void OnVideoEncoded(object source, VideoEventArgs e)
        {
            Console.WriteLine("Mail Service: Sending an e-mail ..." + e.Video.Title);
        }
    }
        
}