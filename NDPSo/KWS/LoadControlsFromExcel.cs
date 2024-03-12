using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

namespace NDPSo.KWS
{
    public class LoadControlsFromExcel
    {

        public static void LoadFromExcel(string filePath, List<string> replacementTexts)
        {
           /* using (WordprocessingDocument doc = WordprocessingDocument.Open(filePath, true))
            {
                Body body = doc.MainDocumentPart.Document.Body;

                foreach (Run run in body.Descendants<Run>().ToList()) // Chuyển sang List để tránh lỗi khi sửa đổi trong vòng lặp
                {
                    string runText = run.InnerText;

                    // Kiểm tra nếu chuỗi có dạng (n)
                    if (runText.StartsWith("(") && runText.EndsWith(")"))
                    {
                        int replacementIndex = int.Parse(runText.Trim('(', ')')) - 1; // Lấy chỉ số từ chuỗi
                        if (replacementIndex >= 0 && replacementIndex < replacementTexts.Count)
                        {
                            Text text = run.GetFirstChild<Text>();
                            if (text != null)
                            {
                                text.Text = replacementTexts[replacementIndex];
                            }
                        }
                    }
                }

                // Lưu lại những thay đổi
                doc.Save();
            }*/
        }
    }
}
