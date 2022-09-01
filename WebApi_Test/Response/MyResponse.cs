namespace WebApi_Test.Response
{
    public class MyResponse
    {
        public Object? Result { get; set; }

        public String?  DisplayMessages { get; set; }
        public List<String>? ErrorMessages { get; set; }

        public bool IsSucces { get; set; }=false;
    }
}
