namespace EduHub.App.Domain;

public class CheckIn
{
    public Guid Id { get; private set; }
    public Guid RegistrationId { get; private set; }
    public DateTime CheckedInAt { get; private set; }
    public string Method { get; private set; } = "";
    private CheckIn() { }

    public static CheckIn Create(Guid maDangKy, string hinhThuc)
    {
        if (maDangKy == Guid.Empty)
        {
            throw new ArgumentException("Ma dang ky khong hop le");
        }
        if (hinhThuc != CheckInMethod.QR && hinhThuc != CheckInMethod.Manual)
        {
            throw new ArgumentException("Hinh thuc check-in khong hop le");
        }

        CheckIn checkIn = new CheckIn();
        checkIn.Id = Guid.NewGuid();
        checkIn.RegistrationId = maDangKy;
        checkIn.CheckedInAt = DateTime.Now;
        checkIn.Method = hinhThuc;
        return checkIn;
    }

   
    public string Summary()
    {
        return "CheckIn luc " + CheckedInAt.ToString("dd/MM/yyyy HH:mm") + " bang " + Method;
    }
}