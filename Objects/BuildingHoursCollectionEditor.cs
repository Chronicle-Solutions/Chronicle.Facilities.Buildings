using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronicle.Facilities.Buildings.Objects
{
    public class BuildingHoursCollectionEditor : CollectionEditor
    {
        public BuildingHoursCollectionEditor(Type type) : base(type)
        {
        }

        protected override bool CanRemoveInstance(object value)
        {
            // Prevent deleting any item
            return false;
        }

        protected override CollectionForm? CreateCollectionForm()
        {
            CollectionForm form = base.CreateCollectionForm();

            if (form is not null)
            {
                form.Text = "Edit Building Hours";
            }

            return form;
        }
    }
}
