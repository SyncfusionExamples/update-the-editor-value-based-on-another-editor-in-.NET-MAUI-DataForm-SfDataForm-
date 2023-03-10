using Syncfusion.Maui.DataForm;
using System.ComponentModel;

namespace EditorValue
{
    public class DataFormBehavior : Behavior<ContentPage>
    {
        private SfDataForm dataForm;
        protected override void OnAttachedTo(ContentPage bindable)
        {
            base.OnAttachedTo(bindable);
            dataForm = bindable.FindByName<SfDataForm>("dataForm");
            if (dataForm != null)
            {
                dataForm.DataObject = new DataFormModel();
                dataForm.ItemsSourceProvider = new ItemSourceProvider();
                dataForm.RegisterEditor("City", DataFormEditorType.ComboBox);
                dataForm.RegisterEditor("Country", DataFormEditorType.AutoComplete);
                dataForm.PropertyChanged += OnDataObjectPropertyChanged;
                dataForm.GenerateDataFormItem += OnGenerateDataFormItem;
            }
        }
        private void OnGenerateDataFormItem(object sender, GenerateDataFormItemEventArgs e)
        {
            if (dataForm != null && e.DataFormItem is DataFormDateItem dateItem)
            {
                dateItem.MaximumDisplayDate = DateTime.Now;
            }
        }
        private void OnDataObjectPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (dataForm.DataObject != null && dataForm.DataObject is DataFormModel dataObject)
            {
                dataObject.Age = DateTime.Now.Year - dataObject.BirthDate.Year;
                dataForm.UpdateEditor("Age");
                if (dataObject.Age != null)
                {
                    if (dataObject.Age >= 18)
                    {
                        dataObject.Eligibility = true;
                    }
                    else
                    {
                        dataObject.Eligibility = false;
                    }

                    dataForm.UpdateEditor("Eligibility");
                }
            }
        }
        protected override void OnDetachingFrom(ContentPage bindable)
        {
            base.OnDetachingFrom(bindable);
            if (dataForm != null)
            {
                dataForm.PropertyChanged -= OnDataObjectPropertyChanged;
                dataForm.GenerateDataFormItem -= OnGenerateDataFormItem;
            }

            dataForm = null;
        }
    }
}