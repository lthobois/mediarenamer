using System.Collections.Generic;
using System.ServiceProcess;
using System.Text;

namespace MediaRenamerService
{
    static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        static void Main()
        {
            ServiceBase[] ServicesToRun;

            // Innerhalb eines Prozesses können mehrere Benutzerdienste ausgeführt werden. Um einen
            // weiteren Dienst zu diesem Prozess hinzuzufügen, ändern Sie die folgende Zeile,
            // um ein zweites Dienstobjekt zu erstellen. Zum Beispiel
            //
            //   ServicesToRun = new ServiceBase[] {new Service1(), new MySecondUserService()};
            //
            ServicesToRun = new ServiceBase[] { new MediaRenamerService() };

            ServiceBase.Run(ServicesToRun);
        }
    }
}