using System.Reflection;
using FullyDynamicConfigurationInterface.FormTemplates;

namespace FullyDynamicConfigurationInterface;

public class FormGenerator {
	public FormGroup GenerateFormGroup(Type dtoType) {
		// TODO cache results
		return new FormGroup(
			dtoType.Name,
			dtoType.GetProperties()
				.ListSelect(GenerateFormItem)
				.ToList()
		);
	}

	private IFormItem GenerateFormItem(PropertyInfo prop) {
		Type type = prop.PropertyType;
		if (type == typeof(Nullable<>)) {
			type = type.GetGenericArguments()[0];
		}

		if (type == typeof(byte) || type == typeof(sbyte) || type == typeof(short) || type == typeof(ushort) || type == typeof(int) || type == typeof(uint) || type == typeof(long) || type == typeof(ulong) || type == typeof(float) || type == typeof(double) || type == typeof(char) || type == typeof(decimal)) {
			return new FormField(prop.Name, FormFieldType.Number);
		} else if (type.IsEnum) {
			return new FormField(prop.Name, FormFieldType.Options, type.GetEnumNames());
		} else if (type == typeof(string)) {
			return new FormField(prop.Name, FormFieldType.Text);
		} else {
			return GenerateFormGroup(type);
		}
	}
}
