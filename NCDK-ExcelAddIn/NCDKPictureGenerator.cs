using NCDK;
using NCDK.Depict;
using NCDK.Renderers.Colors;
using NCDK.Smiles;
using NCDK.Tools.Manipulator;
using static NCDK_ExcelAddIn.ChemStuff;

namespace NCDK_ExcelAddIn
{
    public class NCDKPictureGenerator : IPictureGegerator
    {
        private readonly static object syncLock = new object();

        private static DepictionGenerator pictureGenerator;
        public static DepictionGenerator PictureGenerator
        {
            get
            {
                if (pictureGenerator == null)
                    lock (syncLock)
                    {
                        if (pictureGenerator == null)
                        {
                            pictureGenerator = new DepictionGenerator
                            {
                                AtomColorer = new CDK2DAtomColors(),
                                BackgroundColor = System.Windows.Media.Colors.Transparent,
                            };
                        }
                    }
                return pictureGenerator;
            }
        }

        private static SmilesParser parser = new SmilesParser(CDK.Builder);

        public NCDKPictureGenerator()
        {
        }

        public void Generate(string text, string filename)
        {
            Depiction depict = null;
            if (IsReactionSmilees(text))
            {
                var rxn = parser.ParseReactionSmiles(text);
                ReactionManipulator.PerceiveDativeBonds(rxn);
                ReactionManipulator.PerceiveRadicals(rxn);
                depict = PictureGenerator.Depict(rxn);
            }
            else
            {
                var mol = NCDKExcel.Utility.Parse(text);
                AtomContainerManipulator.PerceiveDativeBonds(mol);
                AtomContainerManipulator.PerceiveRadicals(mol);
                depict = PictureGenerator.Depict(mol);
            }
            depict.WriteTo(filename);
        }

        public TempFile GenerateTemporary(string text)
        {
            var tempFile = new TempFile(".png");
            Generate(text, tempFile.FileName);

            return tempFile;
        }

        public TempFile GenerateTemporary(string text, double width, double height)
        {
            // ignore width and height
            return GenerateTemporary(text);
        }
    }
}
