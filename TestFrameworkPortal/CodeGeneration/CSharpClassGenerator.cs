using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;
using System.CodeDom;
using System.Reflection.Emit;
using System.Reflection;

using System.CodeDom.Compiler;
using Microsoft.CSharp;

namespace TestFrameworkPortal.CodeGeneration
{
    public class CSharpClassGenerator : ICodeGenerator
    {
        private TMS db = new TMS();
        // More Configuration and Work To Continue 
        // This generated class will be 

        CodeCompileUnit targetUnit;
        CodeTypeDeclaration targetClass;
        CodeNamespace frameworkClasses = null;
        private const string System = "System";



        public bool InjectDependentClassCode(TestClassDepnedency dependency)
        {

            // Continue this feature tommorrow ...
            // if the wrapper class exist only 
            try
            {


            }
            catch(Exception excp)
            {


            }
            finally
            {


            }

            return false;

        }


        public bool GenerateCode(CodeConfiguration configuarions)
        {
            bool _isGenerated = false;
            try
            {

                targetUnit = new CodeCompileUnit();
                frameworkClasses = new CodeNamespace(configuarions.ClassToGenerateCode.TestClassNameSpace);
                frameworkClasses.Imports.Add(new CodeNamespaceImport(System));

                targetClass = new CodeTypeDeclaration(configuarions.ClassToGenerateCode.TestClassName);
                targetClass.IsClass = true;
                targetClass.TypeAttributes = TypeAttributes.Public;
                frameworkClasses.Types.Add(targetClass);
                targetUnit.Namespaces.Add(frameworkClasses);
                AddProperties(ref targetClass, configuarions.AllocatedProperties);


            }
            catch (Exception excp)
            {


            }
            finally
            {



            }

            return _isGenerated;

        }



        public string UpdateClassFunctionalityDescription(string message)
        {



            string _message = null;
            try
            {


            }
            catch(Exception excp)
            {



            }
            finally
            {



            }

            return _message;
        }


        // Only Return when generated 
        public List<ClassMethod> ReturnAllMethodsOfClass(TestClassProxy objTestClass)
        {
            Assembly loadedAssembly   =  Assembly.Load(objTestClass.TestClassNameSpace);
            List<Module> modules = null;
            List<MethodInfo> methods = null;
            Module selectedModule = null;
            ClassMethod _classMethod = new ClassMethod();
            List<ClassMethod> classMethods = new List<ClassMethod>();
       
            if(!objTestClass.Generated)
            {
                // Empty Cheat List if not generated 
                return new List<ClassMethod>() ;

            }
           
            try
            {
                modules = loadedAssembly.GetModules().ToList<Module>();

                var selected = from modua in modules
                                     where modua.Name == objTestClass.TestClassName
                                     select modua;
                selectedModule = selected.First<Module>();

                if(selectedModule != null )
                {
                    if(selectedModule.GetMethods().Count<MethodInfo>() > 0 )
                    {
                        methods = selectedModule.GetMethods().ToList();
                    }
                }

                // Wrapped the ClassMethod for methods
                foreach(MethodInfo methodInfo in methods)
                {
                    _classMethod = new ClassMethod();
                    if (methodInfo.IsPublic)
                    {
                        // Display public on Screen 
                        _classMethod.AccessType = "Public";
                    }
                    else
                    {
                        _classMethod.AccessType = "Private";

                    }
                    _classMethod.MethodName = methodInfo.Name;
                    _classMethod.ClassEncapsulatesName = methodInfo.Module.Name;
                    _classMethod.MethodID = Guid.NewGuid();

                    // this will be null once loaded on screen as never tested just generated on server 
                    // _classMethod.MethodTestResults
                    // _classMethod.Tested
                    // at this point it was never tested  
                    classMethods.Add(_classMethod);
                 

                }




            }
            catch(Exception excp)
            {


            }
            finally
            {



            }

            return classMethods;

        }


  



        #region "Get Property Name Type"
        private string GetPropertyNameType(Guid testPropertyId)
        {
            string _propertyName = String.Empty;
            TestProperty property = null;
            TestScriptParameterType parameterType = null;
            try
            {
                  property =db.TestProperties.ToList().Find(p => p.TestPropertyID == testPropertyId);
                  parameterType   =db.TestScriptParameterTypes.ToList().Find(p=>p.TestScriptParamterTypeID == property.TestScriptParameterTypeID);
                 _propertyName = parameterType.TestScriptParameterTypeName;

            }
            catch(Exception excp)
            {


            }
            finally
            {


            }

            return _propertyName;

        }
        #endregion





        private void AddProperties(ref CodeTypeDeclaration targetClass, List<TestPropertyAllocated> allocatedProperties)
        {
            // Declare the read-only Width property.
            CodeMemberProperty widthProperty = null;
            CodeBinaryOperatorExpression areaExpression = null;


            foreach (TestPropertyAllocated allocated in allocatedProperties)
            {


            }


            /*
            new CodeMemberProperty();
                widthProperty.Attributes =
                    MemberAttributes.Public | MemberAttributes.Final;
                widthProperty.Name = "Width";
                widthProperty.HasGet = true;


                widthProperty.Type = new CodeTypeReference(typeof(System.Double));
                widthProperty.Comments.Add(new CodeCommentStatement(
                    "The Width property for the object."));
                widthProperty.GetStatements.Add(new CodeMethodReturnStatement(
                    new CodeFieldReferenceExpression(
                    new CodeThisReferenceExpression(), "widthValue")));
                targetClass.Members.Add(widthProperty);

                // Declare the read-only Height property.
                CodeMemberProperty heightProperty = new CodeMemberProperty();
                heightProperty.Attributes =
                    MemberAttributes.Public | MemberAttributes.Final;
                heightProperty.Name = "Height";
                heightProperty.HasGet = true;
                heightProperty.Type = new CodeTypeReference(typeof(System.Double));
                heightProperty.Comments.Add(new CodeCommentStatement(
                    "The Height property for the object."));
                heightProperty.GetStatements.Add(new CodeMethodReturnStatement(
                    new CodeFieldReferenceExpression(
                    new CodeThisReferenceExpression(), "heightValue")));
                targetClass.Members.Add(heightProperty);

                // Declare the read only Area property.
                CodeMemberProperty areaProperty = new CodeMemberProperty();
                areaProperty.Attributes =
                    MemberAttributes.Public | MemberAttributes.Final;
                areaProperty.Name = "Area";
                areaProperty.HasGet = true;
                areaProperty.Type = new CodeTypeReference(typeof(System.Double));
                areaProperty.Comments.Add(new CodeCommentStatement(
                    "The Area property for the object."));

                // Create an expression to calculate the area for the get accessor 
                // of the Area property.
                areaExpression =
                    new CodeBinaryOperatorExpression(
                    new CodeFieldReferenceExpression(
                    new CodeThisReferenceExpression(), "widthValue"),
                    CodeBinaryOperatorType.Multiply,
                    new CodeFieldReferenceExpression(
                    new CodeThisReferenceExpression(), "heightValue"));
                areaProperty.GetStatements.Add(
                    new CodeMethodReturnStatement(areaExpression));
                targetClass.Members.Add(areaProperty);
                */




        }

    
    private void AddFields()
    {
        // Declare the widthValue field.
    }
}

}