namespace api.Models.Response
{
    public class ErroResponse
    {
        public int Cod { get; set; }
        public string Msn { get; set; }

        public ErroResponse (int cod, string msn)
        {
            this.Cod = cod;
            this.Msn = msn; 
        }
    }
}