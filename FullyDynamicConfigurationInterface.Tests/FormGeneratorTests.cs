using FullyDynamicConfigurationInterface.FormTemplates;
using NUnit.Framework.Constraints;

namespace FullyDynamicConfigurationInterface.Tests;

public class FormGeneratorTests {
	private FormGenerator m_FormGenerator;

	[SetUp]
	public void Setup() {
		m_FormGenerator = new FormGenerator();
	}

	[Test]
	public void BasicTest() {
		var expected = new FormGroup(
			"TestFormModel",
			new[] {
				new FormField("Testfield1", FormFieldType.Text),
				new FormField("Testfield3", FormFieldType.Number),
				new FormField("Testfield5", FormFieldType.Options, new[] { "OptionA", "OptionB", "OptionC" })
			}
		);
        
		FormGroup actual = m_FormGenerator.GenerateFormGroup(typeof(TestFormModel));
		
		Assert.Multiple(() =>
		{
			Assert.That(actual.Label, Is.EqualTo(expected.Label));
			Assert.That(actual.Items, Has.Count.EqualTo(expected.Items.Count));

			void TestField(IFormItem actualItem, IFormItem expectedItem, Constraint modelConstraint) {
				Assert.That(actualItem, Is.TypeOf(expectedItem.GetType()));
				Assert.That(((FormField) actualItem).Label, Is.EqualTo(((FormField) expectedItem).Label));
				Assert.That(((FormField) actualItem).Type, Is.EqualTo(((FormField) expectedItem).Type));
				Assert.That(((FormField) actualItem).Model, modelConstraint);
			}
            
			TestField(actual.Items[0], expected.Items[0], Is.Null);
			TestField(actual.Items[1], expected.Items[1], Is.Null);
			TestField(actual.Items[2], expected.Items[2], Is.TypeOf<string[]>().And.EquivalentTo((string[]) ((FormField) expected.Items[2]).Model!));
		});
	}
}

public class TestFormModel {
	public string Testfield1 { get; set; }
	public int Testfield3 { get; set; }
	public TestEnum Testfield5 { get; set; }
}

public enum TestEnum {
	OptionA, OptionB, OptionC
}
