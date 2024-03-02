namespace WebApiHotel.Helpers
{
    public class Commons
    {
        public static string GenerarCodigoAleatorio()
        {
            const string caracteresPermitidos = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var random = new Random();
            var codigoAleatorio = new char[10];

            for (int i = 0; i < 10; i++)
            {
                codigoAleatorio[i] = caracteresPermitidos[random.Next(caracteresPermitidos.Length)];
            }

            return new string(codigoAleatorio);
        }
    }
}
