namespace ReceptBank.Domain;
public class Recept
{
public string Maträtt { get; set; }
public Recept(string maträtt)
{
Maträtt = maträtt;

}
}