using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace CRUDWebAPI.Clases
{

    public class addstructural
    {
        public int quantity { get; set; }
        public string structuralType { get; set; }
        public string audit { get; set; }
    }
    public class DynamicCommunication
    {
        public bool compliesPop1 { get; set; }
        public bool compliesPop2 { get; set; }
        public bool compliesPop3 { get; set; }
        public int quantity { get; set; }
        public string dynamicType { get; set; }
        public string audit { get; set; }
    }
    public class platformaudit
    {
        public string audit { get; set; }
        public bool compliesPortpholio { get; set; }
        public bool compliesRespect { get; set; }
        public bool compliesCommunication { get; set; }
        public string platformType { get; set; }
        public int totalFronts { get; set; }
        public string exhibitType { get; set; }
    }
    public class typlatfom
    {
        public int id { get; set; }
        public string value { get; set; }
        public string entity { get; set; }
        public string commentaries { get; set; }
    }


    public partial class Cliente
    {
        public string id { get; set; }
        public string name { get; set; }
        public string size { get; set; }
        public string subchannel { get; set; }
        public Route route { get; set; }
        public string type { get; set; }
        public string tradename { get; set; }

    }

    public class RutasdeAuditores
    {
        public ImageSource _image = ImageSource.FromResource("CRUDWebAPI.img.add-friend.png");
        public ImageSource image
        {
            get { return _image; }
            set { _image = value; }
        }
        public string id { get; set; }
        public string supervisor { get; set; }
        public string auditor { get; set; }
        public Cliente client { get; set; }
        public string createdAt { get; set; }
    }
    public partial class Cedi
    {
        public string name { get; set; }
    }

    public partial class Route
    {
        public string routeNumber { get; set; }
    }
    public partial class enfriador
    {
        public string id { get; set; }
        public Type type { get; set; }
        public int doors { get; set; }
        public string client { get; set; }
        public string value { get; set; }
        public bool isInvaded { get; set; }
        public bool firstPosition { get; set; }
        public bool fill75 { get; set; }
        public string[] invasions { get; set; }
        public string cooler { get; set; }
        public string audit { get; set; }
    }

    public partial class SaveEnfriador
    {
        public string id { get; set; }
        public string type { get; set; }
        public int doors { get; set; }
        public string client { get; set; }
        public bool isInvaded { get; set; }
        public bool firstPosition { get; set; }
        public bool fill75 { get; set; }
        public string value { get; set; }
        public string invasions { get; set; }
        public string cooler { get; set; }
        public string audit { get; set; }
    }

    public partial class Type
    {
        public string id { get; set; }
        public string value { get; set; }

    }
    public partial class products
    {
        public string cooler { get; set; }
        public string audit { get; set; }
        public int quantity { get; set; }
        public int singleBottles { get; set; }
        public string product { get; set; }
        public string id { get; set; }
        public int code { get; set; }
        public string description { get; set; }
        public brand brand { get; set; }
        public flavor flavor { get; set; }
        public package package { get; set; }
        public presentation presentation { get; set; }
    }

    public partial class brand
    {
        public int id { get; set; }
        public string name { get; set; }
    }
    public partial class flavor
    {
        public int id { get; set; }
        public string name { get; set; }
    }
    public partial class package
    {
        public int id { get; set; }
        public string packType { get; set; }
        public string abbreviation { get; set; }
    }
    public partial class presentation
    {
        public int id { get; set; }
        public string size { get; set; }
        public string um { get; set; }
    }

    public partial class acomooblock
    {
        public string audit { get; set; }
        public string cooler { get; set; }
        public bool arrFruit { get; set; }
        public bool arrColas { get; set; }
        public bool arrNcbs { get; set; }
        public bool arrHyd { get; set; }
    }

    public partial class tokenjsondes
    {
        public string[] Payload { get; set; }
    }
    public partial class incidenceaudit
    {
        public string audit { get; set; }
        public bool audited { get; set; }
        public string incidence { get; set; }
        public string commentaries { get; set; }


    }

}
