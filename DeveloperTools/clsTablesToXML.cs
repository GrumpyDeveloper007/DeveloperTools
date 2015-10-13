using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Xml;

namespace DeveloperTools
{
    /// <summary>
    /// Scans the meter source code to work out the structure of the optical interface
    /// </summary>
    public class clsTablesToXML
    {
        XmlDocument m_doc_variable = new XmlDocument();

        List<stTableStructure> m_TableStructures = new List<stTableStructure>();
        List<stTable> m_SupportedTables = new List<stTable>();
        List<stTableID> m_AllTablesID = new List<stTableID>();
        List<stDefine> m_Defines = new List<stDefine>();
        List<stUserDefines> m_UserDefines = new List<stUserDefines>();

        string[] m_sHeaderFile;
        string[] m_sSourceFile;

        /// <summary>
        /// Supported meter type configuration
        /// </summary>
        public enum enumConfig
        {
            /// <summary>
            /// U1300
            /// </summary>
            U1300,
            /// <summary>
            /// U1200
            /// </summary>
            U1200
        };

        ///////////////////////////////////////////////////////////////////////////////////////
        // structures

        #region Structures

        struct stUserDefines
        {
            public string sName;
            public string sValue;
        }


        /// <summary>
        /// Used to store the #define in tables.h
        /// </summary>
        struct stDefine
        {
            public string sName;
            public int iValue;
        }

        /// <summary>
        /// Read from tables.c, used to store the actual tables in the meter
        /// </summary>
        struct stTable
        {
            public string sName;
            public string sStructure;
        }

        /// <summary>
        /// Used to store the enum values
        /// </summary>
        struct stTableID
        {
            public string sName;
            public int iValue;
        }

        /// <summary>
        /// Read from tables.h, represents the structures
        /// </summary>
        struct stTableStructure
        {
            public string sStructureName;

            public bool bBitField;
            public List<string> sFields;
            public List<string> sFieldsType;
            public List<string> sDescription;
        }

        /// <summary>
        /// Used to return information needed to generate the grid view
        /// </summary>
        public struct stField
        {
            /// <summary>
            /// Specifies the type of item this is
            /// </summary>
            public enum enumItemType
            {
                /// <summary>
                /// normal values
                /// </summary>
                Default,
                /// <summary>
                /// contains an array of values
                /// </summary>
                Array,
                /// <summary>
                /// contains a collection of values
                /// </summary>
                Structure,
            }
            /// <summary>
            /// Name
            /// </summary>
            public string sName;
            /// <summary>
            /// Type
            /// </summary>
            public string sType;
            /// <summary>
            /// returns true for the root node
            /// </summary>
            public bool bIsTopLevel;
            /// <summary>
            /// string containing bytes
            /// </summary>
            public string sData;
            /// <summary>
            /// description obtained from the code
            /// </summary>
            public string sDescription;
            /// <summary>
            /// Returns true if this is a default values type
            /// </summary>
            public bool bHasChildren;
            /// <summary>
            /// Length of the value in bytes
            /// </summary>
            public int iLength;
            /// <summary>
            /// Type of item
            /// </summary>
            public enumItemType eItemType;

            /// <summary>
            /// 
            /// </summary>
            public int iOffset;
            /// <summary>
            /// 
            /// </summary>
            public int iLevel;
        }

        #endregion

        ///////////////////////////////////////////////////////////////////////////////////////
        // Interface
        
        #region Interface

        /// <summary>
        /// Used to read all the table names defined in the enum
        /// </summary>
        /// <returns></returns>
        public List<string> GetAllTables()
        {
            List<string> ltables = new List<string>();
            foreach (stTableID table in m_AllTablesID)
            {
                ltables.Add(table.sName);
            }
            return ltables;
        }

        /// <summary>
        /// Converts a table name(enum) to the actual table number
        /// </summary>
        /// <param name="sTableName"></param>
        /// <returns></returns>
        public int GetTableNumber(string sTableName)
        {
            string sTemp = ParseTableName(sTableName);

            foreach (stTableID table in m_AllTablesID)
            {
                if (sTemp == table.sName)
                {
                    return table.iValue;
                }
            }
            return 0;
        }

        /// <summary>
        /// Gets the length of the table 
        /// </summary>
        /// <param name="sTableName"></param>
        /// <returns></returns>
        public int GetTableLength(string sTableName)
        {
            string sStructureName = "";
            string sTemp = ParseTableName(sTableName);
            int iTableLength = 0;

            sStructureName = TableNameToStructureName(sTemp);
            iTableLength = GetStructureLength(sStructureName);
            return iTableLength;
        }

        /*
        public List<string> GetFieldData(string sTableName, byte[] bData)
        {
            string sStructureName = "";
            int iLength = 0;
            int iIndex = 0;
            List<string> Data = new List<string>();

            sStructureName = TableNameToStructureName(sTableName);
            stTableStructure table = GetTableByStructureName(sStructureName);
            if (table.sFields != null)
            {
                for (int i = 0; i < table.sFields.Count(); i++)
                {
                    iLength = GetFieldLength(table.sFieldsType[i], table.sFields[i]);
                    if (bData.Length < iIndex + iLength)
                    {
                        Data.Add(BitConverter.ToString(bData, iIndex, bData.Length - iIndex));
                    }
                    else
                    {
                        Data.Add(BitConverter.ToString(bData, iIndex, iLength));
                    }
                    iIndex += iLength;
                }
            }

            return Data;
        }*/

        /// <summary>
        /// Gets a list of tables supported by the meter
        /// </summary>
        /// <returns></returns>
        public List<string> GetSupportedTables()
        {
            List<string> ltables = new List<string>();
            foreach (stTable table in m_SupportedTables)
            {
                ltables.Add(table.sName + " (" + GetTableNumber(table.sName) + ")");
            }
            return ltables;
        }

        /// <summary>
        /// Gets all the fields for a given table name
        /// </summary>
        /// <param name="sTableName"></param>
        /// <param name="bIsTopLevel"></param>
        /// <param name="Data"></param>
        /// <param name="bShowPrefixes"></param>
        /// <returns></returns>
        public List<stField> GetFieldsTableName(string sTableName, bool bIsTopLevel, byte[] Data,bool bShowPrefixes)
        {
            string sStructureName = "";

            string sTemp = ParseTableName(sTableName);

            foreach (stTable sttable in m_SupportedTables)
            {
                if (sttable.sName == sTemp)
                {
                    sStructureName = sttable.sStructure;
                    break;
                }
            }

            return GetFields(sStructureName, bIsTopLevel, Data, 0, "","",bShowPrefixes);
        }

        #endregion

        /// <summary>
        /// Gets all the fields for a given structure name
        /// </summary>
        /// <param name="sStructureName"></param>
        /// <param name="bIsTopLevel"></param>
        /// <param name="bData"></param>
        /// <param name="iIndex"></param>
        /// <param name="sPrefix"></param>
        /// <param name="sSuffix"></param>
        /// <param name="bShowPrefixes"></param>
        /// <returns></returns>
        public List<stField> GetFields(string sStructureName, bool bIsTopLevel, byte[] bData, int iIndex, string sPrefix, string sSuffix, bool bShowPrefixes)
        {
            List<stField> lFields = new List<stField>();

            if (sStructureName.Length > 0)
            {
                stTableStructure table = GetTableByStructureName(sStructureName);

                if (table.bBitField == true)
                {
                    //TODO: Ignore bit fields
                }
                else
                {
                    if (table.sStructureName == null)
                    {
                        //TODO: unsupported table
                    }
                    else
                    {

                        for (int i = 0; i < table.sFields.Count(); i++)
                        {
                            stField Field = new stField();
                            if (bIsTopLevel == false)
                            {
                                Field.sName = sPrefix + table.sFields[i] +sSuffix ;//+ " - "
                            }
                            else
                            {
                                Field.sName = table.sFields[i];
                            }
                            Field.sType = table.sFieldsType[i];
                            Field.bIsTopLevel = bIsTopLevel;
                            Field.sDescription = table.sDescription[i];
                            Field.bHasChildren = !IsBaseType(table.sFieldsType[i], table.sFields[i]);
                            if (Field.bHasChildren)
                            {
                                if (GetTableByStructureName(table.sFieldsType[i]).bBitField == true)
                                {
                                    Field.bHasChildren = false;
                                }
                                if (Field.bHasChildren == true)
                                {
                                    Field.eItemType = stField.enumItemType.Structure;
                                }
                            }
                            Field.iLength = GetFieldLength(table.sFieldsType[i], table.sFields[i]);

                            if (bData != null)
                            {
                                if (bData.Length <= iIndex + Field.iLength)
                                {
                                    if (bData.Length - iIndex > 0)
                                    {
                                        Field.sData = BitConverter.ToString(bData, iIndex, bData.Length - iIndex);
                                    }
                                    else
                                    {
                                        Field.sData = "Unknown";
                                    }
                                }
                                else
                                {
                                    Field.sData = BitConverter.ToString(bData, iIndex, Field.iLength);
                                }
                            }

                            if (IsBaseType(table.sFieldsType[i], table.sFields[i]) == false)
                            {
                                lFields.Add(Field);
                                if (table.sFields[i].Contains("[")==false )
                                {
                                    if (bShowPrefixes)
                                    {
                                        lFields.AddRange(GetFields(table.sFieldsType[i], false, bData, iIndex, sPrefix + table.sFields[i] + ".", "", bShowPrefixes));
                                    }
                                    else
                                    {
                                        lFields.AddRange(GetFields(table.sFieldsType[i], false, bData, iIndex, sPrefix + " - ", "", bShowPrefixes));
                                    }
                                }
                                else
                                {
                                    for (int t = 0; t < GetArraySize(table.sFields[i]); t++)
                                    {

                                        if (bShowPrefixes)
                                        {
                                            lFields.AddRange(GetFields(table.sFieldsType[i], false, bData, iIndex + (t * GetStructureLength(table.sFieldsType[i])), sPrefix + table.sFields[i] + "(" + t.ToString() + ")" + ".", "", bShowPrefixes));//+ t.ToString() + " - "
                                        }
                                        else
                                        {
                                            lFields.AddRange(GetFields(table.sFieldsType[i], false, bData, iIndex + (t * GetStructureLength(table.sFieldsType[i])), sPrefix + "(" + t.ToString() + ")", "", bShowPrefixes));//+ t.ToString() + " - "
                                        }
                                    }
                                }

                            }
                            else
                            {
                                if (table.sFields[i].Contains("["))
                                {
                                    Field.bHasChildren = true;
                                    lFields.Add(Field);
                                    // Look for arrays
                                    for (int t = 0; t < GetArraySize(table.sFields[i]); t++)
                                    {
                                        stField ArrayItem = new stField();
                                        ArrayItem.bHasChildren = false;
                                        ArrayItem.bIsTopLevel = Field.bIsTopLevel;
                                        ArrayItem.sName = Field.sName.Substring(0, Field.sName.IndexOf("[")) + "(" + t.ToString() + ")";//sPrefix
                                        ArrayItem.sType = Field.sType;
                                        ArrayItem.iLength = GetFieldLength(ArrayItem.sType, ArrayItem.sName);
                                        if (bData != null)
                                        {
                                            if (iIndex + (ArrayItem.iLength * t) + ArrayItem.iLength <= bData.Length)
                                            {
                                                ArrayItem.sData = BitConverter.ToString(bData, iIndex + (ArrayItem.iLength * t), ArrayItem.iLength);
                                            }
                                        }
                                        ArrayItem.sDescription = Field.sDescription;
                                        ArrayItem.eItemType = stField.enumItemType.Array;
                                        lFields.Add(ArrayItem);
                                    }
                                }
                                else
                                {
                                    lFields.Add(Field);

                                }

                            }
                            iIndex += Field.iLength;
                        }
                    }
                }
            }
            return lFields;
        }


        /// <summary>
        /// Processes a XML that describes a read or write function
        /// </summary>
        /// <param name="sXML"></param>
        /// <returns></returns>
        public bool SendXML(string sXML)
        {
            //TODO: unfinished
            // looks like -
            // <Read/Write Data>
            // <TableName>
            // <FieldName>
            XmlDocument docXML = new XmlDocument();
            string sTableName;
            //bool bReadCommand;
            string sRootNodeName="";
            docXML.LoadXml (sXML);

            if (docXML.SelectSingleNode("ReadData") != null)
            {
                sRootNodeName = "ReadData";
                sTableName = docXML.SelectSingleNode("ReadData").InnerText ;
            }
            else
                if (docXML.SelectSingleNode("WriteData") != null)
                {
                    sRootNodeName = "WriteData";
                    sTableName = docXML.SelectSingleNode("WriteData").InnerText;
                }

            if (sRootNodeName.Length > 0)
            {
                foreach (XmlNode node in docXML.SelectNodes(sRootNodeName))
                {
                    //stDefine newDefine = new stDefine();
                    //newDefine.sName = node.SelectSingleNode("Name").InnerText;
                    //newDefine.iValue = int.Parse(node.SelectSingleNode("Value").InnerText);
                }

                return true;
            }
            else
            {
                return false;
            }


        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        #region Load/Save XML
        /// <summary>
        /// Loads a previously saved xml configuration that describes all the tables in a meter
        /// </summary>
        /// <param name="sFileName"></param>
        public void LoadXML(string sFileName)
        {
            XmlDocument docXML = new XmlDocument();
            docXML.Load(sFileName);

            m_Defines.Clear();
            foreach (XmlNode node in docXML.SelectNodes("OpticalInterface/Defines/Define"))
            {
                stDefine newDefine = new stDefine();
                newDefine.sName = node.SelectSingleNode("Name").InnerText;
                newDefine.iValue = int.Parse(node.SelectSingleNode("Value").InnerText);
                m_Defines.Add(newDefine);
            }

            m_AllTablesID.Clear();
            foreach (XmlNode node in docXML.SelectNodes("OpticalInterface/AllTables/Table"))
            {
                stTableID newTable = new stTableID();
                newTable.sName = node.SelectSingleNode("Name").InnerText;
                newTable.iValue = int.Parse(node.SelectSingleNode("Value").InnerText);
                m_AllTablesID.Add(newTable);
            }

            m_SupportedTables.Clear();
            foreach (XmlNode node in docXML.SelectNodes("OpticalInterface/SupportedTables/SupportedTable"))
            {
                stTable newTable = new stTable();
                newTable.sName = node.SelectSingleNode("Name").InnerText;
                newTable.sStructure = node.SelectSingleNode("StructureName").InnerText;
                m_SupportedTables.Add(newTable);
            }

            m_TableStructures.Clear();
            foreach (XmlNode node in docXML.SelectNodes("OpticalInterface/Tables/Table"))
            {
                stTableStructure newTable = new stTableStructure();
                newTable.sFields = new List<string>();
                newTable.sFieldsType = new List<string>();
                newTable.sDescription = new List<string>();
                newTable.sStructureName = node.SelectSingleNode("Name").InnerText;
                newTable.bBitField = bool.Parse(node.SelectSingleNode("BitField").InnerText);


                foreach (XmlNode fieldnode in node.SelectNodes("Fields/Field"))
                {
                    newTable.sFields.Add(fieldnode.SelectSingleNode("Name").InnerText);
                    newTable.sFieldsType.Add(fieldnode.SelectSingleNode("Type").InnerText);
                    newTable.sDescription.Add(fieldnode.SelectSingleNode("Description").InnerText);
                }
                m_TableStructures.Add(newTable);
            }
        }

        /// <summary>
        /// Creates a xml file that describes all the supported functions in a meter
        /// </summary>
        /// <param name="sFileName"></param>
        public void ExportXML(string sFileName)
        {
            string sXML = "";
            //List<stTableID> m_AllTablesID = new List<stTableID>();
            sXML += "<OpticalInterface>";

            sXML += "\t<Defines>";
            foreach (stDefine stDefine in m_Defines)
            {
                sXML += "\t\t<Define>\r\n";
                sXML += "\t\t<Name>" + stDefine.sName + "</Name>\r\n";
                sXML += "\t\t<Value>" + stDefine.iValue.ToString() + "</Value>\r\n";
                sXML += "\t\t</Define>\r\n";
            }
            sXML += "\t</Defines>\r\n";

            sXML += "\t<AllTables>";
            foreach (stTableID TableID in m_AllTablesID)
            {
                sXML += "\t\t<Table>\r\n";
                sXML += "\t\t<Name>" + TableID.sName + "</Name>\r\n";
                sXML += "\t\t<Value>" + TableID.iValue.ToString() + "</Value>\r\n";
                sXML += "\t\t</Table>\r\n";
            }
            sXML += "\t</AllTables>\r\n";



            sXML += "\t<SupportedTables>\r\n";
            foreach (stTable sttable in m_SupportedTables)
            {
                sXML += "\t\t<SupportedTable>\r\n";
                sXML += "\t\t<Name>" + sttable.sName + "</Name>\r\n";
                sXML += "\t\t<StructureName>" + sttable.sStructure + "</StructureName>\r\n";
                sXML += "\t\t</SupportedTable>\r\n";
            }
            sXML += "\t</SupportedTables>\r\n";


            sXML += "\t<Tables>\r\n";
            foreach (stTableStructure stTable in m_TableStructures)
            {
                sXML += "\t\t<Table>\r\n";
                sXML += "\t\t\t<Name>" + stTable.sStructureName + "</Name>\r\n";
                sXML += "\t\t\t<BitField>" + stTable.bBitField.ToString() + "</BitField>\r\n";

                sXML += "\t\t\t<Fields>\r\n";
                for (int i = 0; i < stTable.sDescription.Count; i++)
                {
                    sXML += "\t\t\t\t<Field>\r\n";
                    sXML += "\t\t\t\t<Name>" + stTable.sFields[i] + "</Name>\r\n";
                    sXML += "\t\t\t\t<Type>" + stTable.sFieldsType[i] + "</Type>\r\n";
                    sXML += "\t\t\t\t<Description>" + stTable.sDescription[i] + "</Description>\r\n";
                    sXML += "\t\t\t\t</Field>\r\n";
                }
                sXML += "\t\t\t</Fields>\r\n";

                sXML += "\t\t</Table>\r\n";
            }
            sXML += "\t</Tables>\r\n";

            sXML += "</OpticalInterface>";

            sXML = sXML.Replace("&", "&amp;");

            System.IO.File.WriteAllText(sFileName, sXML);
        }
        #endregion
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        #region Code file scanning

        /// <summary>
        /// Scans a U series code folder for table entries
        /// </summary>
        /// <param name="sPath"></param>
        public void ScanFile(string sPath)
        {
            string[] sMetrologyFile = System.IO.File.ReadAllText(sPath + @"\AMPYEMAIL\metrologystructs.h").Split('\n');
            m_sHeaderFile = System.IO.File.ReadAllText(sPath + @"\AMPYEMAIL\tables.h").Split('\n');
            m_sSourceFile = System.IO.File.ReadAllText(sPath + @"\AMPYEMAIL\tables.c").Split('\n');

            ReadDefines();

            ReadAllTables();

            ReadSupportedTables();
            /*typedef struct
{
unsigned short tbl_proc_nbr      : 11;//table or procedure number
unsigned short std_vs_mfg_flag   : 1;//0=standard table 1=manufacturing table
unsigned short selector          : 4;//0=on completion post to tbl8 , 1=on exception post to tbl8, 2=dont post to tbl8, 3=immediate post to tbl8 and then on completion post to tbl8 again
} _table_idb_bfld_t;//TABLE_IDB_BFLD
*/
            ReadStructures(sMetrologyFile);

            ReadStructures(m_sHeaderFile);


        }

        private void ReadStructures(string[] sFile)
        {
            bool bStartFound = false;
            bool bInHashIf = false;
            bool bInComment = false;
            bool bSkipUnionExtraLines = false;
            bool bFirstLineOfUnion = false;
            int iUnionRef = 0;
            int iOpenStructureCount = 0;
            stTableStructure stCurrentTable = new stTableStructure();
            string sTestBuffer = "";

            bStartFound = false;

            for (int i = 0; i < sFile.Count(); i++)
            {
                string sLine = sFile[i].Replace('\t', ' ');

                string sStructureName;
                if (sLine.Contains("/*"))
                {
                    bInComment = true;
                }
                sTestBuffer += sLine + "\r\n";



                if (bInComment == false)
                {
                    if (sLine.Trim().ToUpper().StartsWith("union".ToUpper()))
                    {
                        // oh no
                        bSkipUnionExtraLines = true;
                        iUnionRef = iOpenStructureCount;
                        bFirstLineOfUnion = true;
                    }

                    if (sLine.ToUpper().Contains("typedef struct".ToUpper()) || sLine.StartsWith ("struct")==true )
                    {
                        bStartFound = true;
                        bInHashIf = false;
                        stCurrentTable = new stTableStructure();
                        stCurrentTable.sFields = new List<string>();
                        stCurrentTable.sFieldsType = new List<string>();
                        stCurrentTable.sDescription = new List<string>();
                        stCurrentTable.bBitField = false;

                        if (sLine.Trim().EndsWith("{"))
                        {
                            iOpenStructureCount++;
                        }
                        if (sLine.StartsWith("struct") == true)
                        {
                            stCurrentTable.sStructureName = sLine.Replace("{", "").Trim();
                        }

                    }

                    if (bStartFound)
                    {
                        int iStartPos = sLine.IndexOf("sizeof(");
                        int iEndPos = 0;

                        if (sLine.Trim().StartsWith("{"))
                        {
                            iOpenStructureCount++;
                        }

                        if (sLine.Trim().StartsWith("}"))
                        {
                            iOpenStructureCount--;
                            if (iOpenStructureCount == iUnionRef)
                            {
                                bSkipUnionExtraLines = false;
                            }
                            else
                            {
                                bFirstLineOfUnion = false;
                            }

                            if (iOpenStructureCount == 0)
                            {

                                iEndPos = sLine.Trim().IndexOf(";");
                                sStructureName = sLine.Trim().Substring(1, iEndPos - 1).Trim();
                                if (sStructureName.Length > 0)
                                {
                                    stCurrentTable.sStructureName = sStructureName;
                                }
                                m_TableStructures.Add(stCurrentTable);

                                bStartFound = false;
                                sTestBuffer = "";
                            }
                        }
                        else
                        {
                            if (sLine.ToUpper().Contains("#if".ToUpper()))
                            {
                                string[] sTokens = sLine.Replace("\r", "").Split(' ');
                                sTokens[1] = ReplaceDefines(sTokens[1]);
                                sTokens[1] = ReplaceDefines(sTokens[1]);
                                NCalc.Expression a = new NCalc.Expression(sTokens[1]);// TODO: make better
                                int t;
                                try
                                {
                                    t = Convert.ToInt32(a.Evaluate());
                                }
                                catch (Exception ex)
                                {
                                    t = 1;
                                }
                                if (t == 0)
                                {


                                    bInHashIf = true;
                                }
                            }

                            // just ignore #else variable for now
                            if (sLine.ToUpper().Contains("#else".ToUpper()) || sLine.ToUpper().Contains("#elif".ToUpper())) //#elif
                            {
                                bInHashIf = true;
                            }

                            if (sLine.ToUpper().Contains("#endif".ToUpper()))
                            {
                                bInHashIf = false;
                            }

                            if (sLine.Contains(";") && bInHashIf == false && sLine.Trim().Contains(" ") && sLine.Trim().StartsWith("//") == false && (bSkipUnionExtraLines == false
                            || (bSkipUnionExtraLines == true && bFirstLineOfUnion == true)))
                            {
                                if (iOpenStructureCount == iUnionRef+1)
                                {
                                    bFirstLineOfUnion = false;
                                }

                                //   unsigned char  hour;
                                int iSemiColonPos = sLine.IndexOf(';');
                                int iSpacePos = sLine.LastIndexOf(' ', iSemiColonPos);
                                int iCommandPos = sLine.LastIndexOf("//");
                                if (iCommandPos > 0)
                                {
                                    stCurrentTable.sDescription.Add(sLine.Substring(iCommandPos + 2).Replace("\r", ""));
                                }
                                else
                                {
                                    stCurrentTable.sDescription.Add("");
                                }

                                string sFieldType = GetVaribleType(sLine);
                                if (sLine.Substring(iSpacePos - 1, iSemiColonPos - iSpacePos).Trim().Contains(":"))
                                {
                                    // contains bit field :(
                                    stCurrentTable.bBitField = true;
                                    stCurrentTable.sFields.Add(sLine);
                                    stCurrentTable.sFieldsType.Add(sLine);
                                }
                                else
                                {
                                    stCurrentTable.sFields.Add(sLine.Substring(iSpacePos, iSemiColonPos - iSpacePos).Trim());
                                    stCurrentTable.sFieldsType.Add(sLine.Substring(0, iSpacePos).Trim());
                                }
                            }
                        }
                    }
                }

                if (sLine.Contains("*/"))
                {
                    bInComment = false;
                }


            }

        }


        private void ReadDefines()
        {
            int iLognest = 0;
            List<stDefine> lDefines = new List<stDefine>();

            foreach (string sLine2 in m_sHeaderFile)
            {
                string sLine = sLine2.ToUpper().Replace('\t', ' ').Replace('\r', ' ').Trim();
                if (sLine.StartsWith("#define".ToUpper()))
                {
                    int iCommentStart = sLine.LastIndexOf("//");
                    if (iCommentStart < 0)
                    {
                        iCommentStart = sLine.LastIndexOf("/*");
                    }
                    if (iCommentStart > 0)
                    {
                        sLine = sLine.Substring(0, iCommentStart).Trim();
                    }
                    int iValueStart = sLine.LastIndexOf(' ');
                    int iNameStart = sLine.IndexOf(' ');
                    int iNameEnd = sLine.IndexOf(" ", iNameStart + 1);

                    //#define NUMBER_OF_ELEMENTS             3     // single or polyphase?
                    int iResult;
                    if (iNameEnd > 0 && iValueStart >= iNameEnd && int.TryParse(sLine.Substring(iValueStart), out iResult))
                    {
                        stDefine stADefine = new stDefine();
                        stADefine.sName = sLine.Substring(iNameStart, iNameEnd - iNameStart).Trim();
                        stADefine.iValue = int.Parse(sLine.Substring(iValueStart));
                        if (stADefine.sName.Length > iLognest)
                        {
                            iLognest = stADefine.sName.Length;
                        }
                        lDefines.Add(stADefine);
                    }
                }
            }

            stDefine stADefine2 = new stDefine();
            stADefine2.sName = "defined(1)||";
            stADefine2.iValue = 1;
            lDefines.Add(stADefine2);

            // sort defines by length
            for (int i = iLognest; i > 0; i--)
            {
                foreach (stDefine def in lDefines)
                {
                    if (def.sName.Length == i)
                    {
                        m_Defines.Add(def);
                    }
                }

            }


        }

        private void ReadAllTables()
        {
            string sTablesXML = "<tables>";
            int iCurrentTableNumber = 0;
            bool bStartFound = false;

            // Read tables 
            foreach (string sLine in m_sHeaderFile)
            {
                int iCommaPos = sLine.IndexOf(',');
                int iEqualPos = sLine.IndexOf('=');
                if (sLine.ToUpper().Contains("eStdT00_GenConfig".ToUpper()))
                {
                    bStartFound = true;
                }

                if (bStartFound)
                {
                    if (sLine.Contains("}"))
                    {
                        break;
                    }

                    if (iCommaPos > 0 && (iCommaPos < iEqualPos || iEqualPos == -1))
                    {
                        sTablesXML += "<table Number='" + iCurrentTableNumber.ToString() + "'>" + sLine.Substring(0, iCommaPos).Trim() + "</table>\r\n";

                        stTableID table = new stTableID();
                        table.sName = sLine.Substring(0, iCommaPos).Trim();
                        table.iValue = iCurrentTableNumber;
                        m_AllTablesID.Add(table);


                        iCurrentTableNumber++;
                    }
                    else if (iEqualPos > 0)
                    {
                        if (sLine.Contains("ANSI_MANFCT_TABLE_OFFSET"))
                        {
                            iCurrentTableNumber = 2048;
                        }
                        else if (sLine.Contains("ANSI_KF_CLASS_TABLE_OFFSET+140"))
                        {
                            iCurrentTableNumber = 2148 + 140;
                        }
                        else if (sLine.Contains("ANSI_KF_CLASS_TABLE_OFFSET"))
                        {
                            iCurrentTableNumber = 2148;
                        }
                        sTablesXML += "<table Number='" + iCurrentTableNumber.ToString() + "'>" + sLine.Substring(0, iEqualPos).Trim() + "</table>\r\n";

                        stTableID table = new stTableID();
                        table.sName = sLine.Substring(0, iEqualPos).Trim();
                        table.iValue = iCurrentTableNumber;
                        m_AllTablesID.Add(table);

                        iCurrentTableNumber++;
                    }
                    else
                    {
                        // Unable to process line 
                        iCurrentTableNumber = 0;
                    }
                }
            }
            sTablesXML += "</tables>";

        }

        private void ReadSupportedTables()
        {
            bool bStartFound = false;

            // Get links between tables and structures
            //const _TableInfoStruct TableConfig[] =
            bStartFound = false;
            foreach (string sLine in m_sSourceFile)
            {
                string sStructureName = "";
                string sTableName = "";
                string[] sTokens = sLine.Split(',');
                if (sLine.ToUpper().Contains("const _TableInfoStruct".ToUpper()))
                {
                    bStartFound = true;
                }

                if (bStartFound)
                {
                    int iStartPos = sLine.IndexOf("sizeof(");
                    int iEndPos = 0;

                    if (sLine.Contains("eMaxTables"))
                    {
                        break;
                    }

                    if (iStartPos > 0)
                    {
                        iEndPos = sLine.IndexOf(')', iStartPos);
                        if (iEndPos > 0)
                        {
                            iStartPos += "sizeof(".Length;
                            sStructureName = sLine.Substring(iStartPos, iEndPos - iStartPos);
                        }
                    }

                    iStartPos = sLine.IndexOf('{');
                    iEndPos = sLine.IndexOf(',');
                    if (iStartPos > 0 && iEndPos > 0)
                    {
                        iStartPos += 1;
                        sTableName = sLine.Substring(iStartPos, iEndPos - iStartPos);
                    }

                    if (sTableName.Length > 0)
                    {
                        if (sStructureName.Length > 0)
                        {
                            stTable t;
                            t.sName = sTableName;
                            t.sStructure = sStructureName;
                            m_SupportedTables.Add(t);

                        }
                        else
                        {
                            if (sTokens[2].Trim() == "eDynamic")
                            {

                                stTable t;
                                t.sName = sTableName;
                                t.sStructure = "eDynamic";
                                m_SupportedTables.Add(t);
                            }
                        }
                    }
                    //{eStdT00_GenConfig,     sizeof(_std_table_00_t),eConst,     (void HUGE*)&std_table_00_struct,NULL},
                    // search for the sizeof as this part of the string is the least complex
                }

            }


        }


        string GetVaribleType(string sLine)
        {
            sLine = sLine.Trim().ToUpper();
            if (sLine.StartsWith("Unsigned Char".ToUpper()))
            {
                return "unsigned char";
            }
            if (sLine.StartsWith("Unsigned short".ToUpper()))
            {
                return "unsigned short";
            }
            if (sLine.StartsWith("Unsigned long".ToUpper()))
            {
                return "unsigned long";
            }
            if (sLine.StartsWith("signed Char".ToUpper()))
            {
                return "signed char";
            }
            if (sLine.StartsWith("signed short".ToUpper()))
            {
                return "signed short";
            }
            if (sLine.StartsWith("signed long".ToUpper()))
            {
                return "signed long";
            }
            if (sLine.StartsWith("ni_fmat1_t".ToUpper()))
            {
                return "signed long";
            }

            if (sLine.StartsWith("ni_fmat2_t".ToUpper()))
            {
                return "signed long";
            }

            foreach (stTableStructure table in m_TableStructures)
            {
                if (sLine.StartsWith(table.sStructureName.ToUpper()))
                {
                    return table.sStructureName;
                }
            }

            //typedef signed long ni_fmat1_t;//NI_FMAT1 -ANSI only allows for a signed 32 number (thats ok we will just never use the negative)
            //typedef signed long ni_fmat2_t;//NI_FMAT2 -ANSI only allows for a signed 32 number (thats ok we will just never use the negative)


            return sLine.Substring(0, sLine.IndexOf(' '));
        }

        #endregion

        /// <summary>
        /// Sets up some constants depending on the meter configuration
        /// </summary>
        /// <param name="eConfig"></param>
        public void SetConfiguration(enumConfig eConfig)
        {
            m_UserDefines.Clear();
            switch (eConfig)
            {
                case enumConfig.U1200:

                    break;
                case enumConfig.U1300:
                    stUserDefines Setting1 = new stUserDefines();
                    Setting1.sName = "ROM_A0000";
                    Setting1.sValue = "1";
                    m_UserDefines.Add(Setting1);

                    stUserDefines Setting2 = new stUserDefines();
                    Setting2.sName = "CPU_M16C";
                    Setting2.sValue = "1";
                    m_UserDefines.Add(Setting2);

                    stUserDefines Setting3 = new stUserDefines();
                    Setting3.sName = "AMPY_METER_U1300";
                    Setting3.sValue = "1";
                    m_UserDefines.Add(Setting3);


                    stUserDefines Setting4 = new stUserDefines();
                    Setting4.sName = "RELAYLIFETEST";
                    Setting4.sValue = "0";
                    m_UserDefines.Add(Setting4);

                    stUserDefines Setting5 = new stUserDefines();
                    Setting5.sName = "NEUTRAL_INTEGRITY";
                    Setting5.sValue = "0";
                    m_UserDefines.Add(Setting5);

                    break;
            }

        }


        private string ReplaceDefines(string sParameter)
        {
            foreach (stDefine Define in m_Defines)
            {
                sParameter = sParameter.Replace(Define.sName, Define.iValue.ToString());
            }

            foreach (stUserDefines Define in m_UserDefines )
            {
                sParameter = sParameter.Replace(Define.sName.ToUpper(), Define.sValue);
            }
            
            return sParameter;
        }

        private int GetArraySize(string sFieldName)
        {
            int iLength = 1;
            int iStart = 0;
            if (sFieldName.Contains('['))
            {
                while (sFieldName.IndexOf('[', iStart) > 0)
                {
                    string sDimension;
                    int iAStart = sFieldName.IndexOf('[', iStart);
                    int iAEnd = sFieldName.IndexOf(']', iStart + 1);
                    sDimension = sFieldName.Substring(iAStart + 1, iAEnd - iAStart - 1);

                    sDimension=ReplaceDefines(sDimension);

                    NCalc.Expression a = new NCalc.Expression(sDimension.Replace("eHashNumber", "32"));// TODO: make better
                    int t = Convert.ToInt32(a.Evaluate());

                    iLength = iLength * t;
                    iStart = iAEnd;
                }

                return iLength;
            }
            else
            {
                return 1;
            }
        }

        private int GetFieldLength(string sFieldType, string sFieldName)
        {
            string sFieldTypeLocal = sFieldType.Trim().ToUpper();

            if (sFieldTypeLocal == "Unsigned Char".ToUpper())
            {
                return 1 * GetArraySize(sFieldName);
            }
            if (sFieldTypeLocal == "Unsigned short".ToUpper())
            {
                return 2 * GetArraySize(sFieldName);
            }
            if (sFieldTypeLocal == "Unsigned long".ToUpper())
            {
                return 4 * GetArraySize(sFieldName);
            }
            if (sFieldTypeLocal == "signed Char".ToUpper())
            {
                return 1 * GetArraySize(sFieldName);
            }
            if (sFieldTypeLocal == "signed short".ToUpper())
            {
                return 2 * GetArraySize(sFieldName);
            }
            if (sFieldTypeLocal == "signed long".ToUpper())
            {
                return 4 * GetArraySize(sFieldName);
            }
            if (sFieldTypeLocal == "ni_fmat1_t".ToUpper())
            {
                return 4 * GetArraySize(sFieldName);
            }

            if (sFieldTypeLocal == "ni_fmat2_t".ToUpper())
            {
                return 4 * GetArraySize(sFieldName);
            }

            return GetStructureLength(sFieldTypeLocal) * GetArraySize(sFieldName);
        }

        private bool IsBaseType(string sFieldType, string sFieldName)
        {
            string sFieldTypeLocal = sFieldType.Trim().ToUpper();

            if (sFieldTypeLocal.StartsWith("Unsigned Char".ToUpper()))
            {
                return true;
            }
            if (sFieldTypeLocal.StartsWith("Unsigned short".ToUpper()))
            {
                return true;
            }
            if (sFieldTypeLocal.StartsWith("Unsigned long".ToUpper()))
            {
                return true;
            }
            if (sFieldTypeLocal.StartsWith("signed Char".ToUpper()))
            {
                return true;
            }
            if (sFieldTypeLocal.StartsWith("signed short".ToUpper()))
            {
                return true;
            }
            if (sFieldTypeLocal.StartsWith("signed long".ToUpper()))
            {
                return true;
            }
            if (sFieldTypeLocal.StartsWith("ni_fmat1_t".ToUpper()))
            {
                return true;
            }

            if (sFieldTypeLocal.StartsWith("ni_fmat2_t".ToUpper()))
            {
                return true;
            }

            return false;
        }

        private int GetStructureLength(string sStructureName)
        {
            int iTableLength = 0;
            stTableStructure table = GetTableByStructureName(sStructureName);

            if (table.sStructureName != null)
            {

                if (table.bBitField == true)
                {
                    if (table.sFields[0].ToUpper().Contains("short".ToUpper()))
                    {
                        return 2;
                    }
                    else
                    {
                        if (table.sFields[0].ToUpper().Contains("char".ToUpper()))
                        {
                            return 1;
                        }
                        else
                            if (table.sFields[0].ToUpper().Contains("long".ToUpper()))
                            {
                                return 4;
                            }
                            else
                            {
                                return 0; // error
                            }
                    }
                }
                else
                {

                    for (int i = 0; i < table.sFields.Count(); i++)
                    {
                        iTableLength += GetFieldLength(table.sFieldsType[i], table.sFields[i]);
                    }
                }
            }
            if (iTableLength == 0)
            {
                // TODO: unable to find structure
            }


            return iTableLength;
        }


        #region Helper Functions
        /// <summary>
        /// Gets the structure used to define the table
        /// </summary>
        /// <param name="sTableName"></param>
        /// <returns></returns>
        private string TableNameToStructureName(string sTableName)
        {
            string sStructureName = "";

            foreach (stTable table in m_SupportedTables)
            {
                if (table.sName == sTableName)
                {
                    sStructureName = table.sStructure;
                    break;
                }
            }
            return sStructureName;
        }

        private stTableStructure GetTableByStructureName(string sStructureName)
        {
            foreach (stTableStructure table in m_TableStructures)
            {
                if (table.sStructureName.ToUpper() == sStructureName.ToUpper())
                {
                    return table;
                }
            }
            return new stTableStructure();
        }

        /// <summary>
        /// When showing the table name we add the actual number to the end of the string, here we remove it so we can find the correct structure
        /// </summary>
        /// <param name="sTableName"></param>
        /// <returns></returns>
        private string ParseTableName(string sTableName)
        {
            if (sTableName.Contains("("))
            {
                return sTableName.Substring(0, sTableName.IndexOf("(")).Trim();
            }
            return sTableName;

        }

        #endregion


        private string RemoveArray(string sFieldName)
        {
            return sFieldName;
        }

        /// <summary>
        /// Works out the offset and length for a given field name
        /// </summary>
        /// <param name="sTableName"></param>
        /// <param name="sFieldName"></param>
        /// <param name="iOffset"></param>
        /// <param name="iLength"></param>
        /// <param name="bShowPrefixes"></param>
        public void CalcOffsetAndLength(string sTableName, string sFieldName, ref int iOffset, ref int iLength, bool bShowPrefixes)
        {
            List<clsTablesToXML.stField> stLastFieldSet;

            byte[] ReadData = null;
            iOffset = 0;
            stLastFieldSet = GetFieldsTableName(sTableName, true, ReadData, bShowPrefixes);

            foreach (clsTablesToXML.stField sParamaterName in stLastFieldSet)
            {
                if (sFieldName.ToUpper() == sParamaterName.sName.ToUpper())
                {
                    iLength = sParamaterName.iLength;
                    return;
                }

                if (sParamaterName.bHasChildren == false)
                {
                    iOffset += sParamaterName.iLength;
                }

            }
            iOffset = 0;
            iLength = 0;
        }


    }
}
