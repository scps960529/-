namespace CustomComponents.WindowForm.Wizards
{
    public interface IWizardModel
    {
        /// <summary>
        /// For select mode.
        /// Don't release the set method, this function is only for Manager class.
        /// </summary>
        int LabelFlag { get; }
        /// <summary>
        /// For user define. Such as Name, Enum...etc.
        /// </summary>
        string Label { get; }
    }
}
