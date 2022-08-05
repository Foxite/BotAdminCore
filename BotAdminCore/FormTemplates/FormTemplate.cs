namespace BotAdminCore.FormTemplates; 

public class Form {
	public string Title { get; }
	public IList<FormFieldGroup> FieldGroups { get; }

	public Form(string title, params FormFieldGroup[] fieldGroups) {
		Title = title;
		FieldGroups = fieldGroups;
	}
}

public class FormFieldGroup {
	public string Label { get; }
	public IList<FormField> Fields { get; }

	public FormFieldGroup(string label, params FormField[] fields) {
		Label = label;
		Fields = fields;
	}
}

public class FormField {
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
	Date,
	Options,
}
