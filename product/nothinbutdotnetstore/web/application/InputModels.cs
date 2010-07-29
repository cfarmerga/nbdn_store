namespace nothinbutdotnetstore.web.application
{
    public static class InputModels
    {
        public static class department
        {
            public static readonly PayloadKey<string> name = new PayloadKey<string>("name");
            public static readonly PayloadKey<long> id = new PayloadKey<long>("id");
        }
    }
}