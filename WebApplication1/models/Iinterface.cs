namespace WebApplication1.models
{
    public interface  Iinterface
    {
        IEnumerable<Emplistclass> getall();  //----------------------------Get method
        Emplistclass  Postdata(Emplistclass emplistclass);//---------------create method
        Emplistclass Updatedata(Emplistclass emplistclass1,int id);//------update method
        Emplistclass deletdata(Emplistclass emplistclass5,int id);//----------------------------------delete method

    }
}
