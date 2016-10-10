using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HideAndSeek
{
    class OutsideWithDoorHidingPlace : OutsideWithDoor, IHidingPlace
    {
        public string HidingPlaceName { get; private set; }
        public OutsideWithDoorHidingPlace(string name, bool hot, string doorDescription, string hidingPlaceName) : base(name, hot, doorDescription)
        {
            HidingPlaceName = hidingPlaceName;
        }
        public override string Description
        {
            get
            {
                return base.Description + " Someone could hide " + HidingPlaceName + ".";
            }
        }
    }
}
