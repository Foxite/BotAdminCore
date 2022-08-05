namespace BotAdminCore.FormTemplates;

public interface IFormFieldGroupItem { }

public class BFormGroup : IFormFieldGroupItem {
	public string Label { get; }
	public IList<IFormFieldGroupItem> Items { get; }

	public BFormGroup(string label, params IFormFieldGroupItem[] items) {
		Label = label;
		Items = items;
	}
}

public class FormField : IFormFieldGroupItem {
	public string Label { get; }
	public FormFieldType Type { get; }
	
	/// <summary>
	/// Arbitrary object specifying restrictions on the field value.
	/// Expected to be a regex for Text, Min/Max for Number and Date, and string[] for Options.
	/// </summary>
	// TODO specify model as class
	public object? Model { get; }

	public FormField(string label, FormFieldType type, object? model = null) {
		Label = label;
		Type = type;
		Model = model;
	}
}

public enum FormFieldType {
	Text,
	Number,
	Options,
}
