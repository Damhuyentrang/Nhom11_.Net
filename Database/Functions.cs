using System;
using System.Text;

namespace BTL_nhom11_marketPC.Database
{
    public static class Functions 
    {
        public static string ChuyenSoSangChu(decimal number)
        {
            // Làm tròn số decimal thành số nguyên (bỏ phần thập phân)
            long intNumber = (long)Math.Floor(number); // Làm tròn xuống, hoặc dùng Math.Round nếu muốn làm tròn gần nhất

            // Kiểm tra số âm
            bool isNegative = intNumber < 0;
            if (isNegative)
            {
                intNumber = Math.Abs(intNumber);
            }

            // Trường hợp số 0
            if (intNumber == 0)
            {
                return "Không đồng";
            }

            // Chuyển số thành chuỗi
            string sNumber = intNumber.ToString();
            int mLen = sNumber.Length - 1;

            // Các mảng hỗ trợ
            string[] mNumText = "không;một;hai;ba;bốn;năm;sáu;bảy;tám;chín".Split(';');
            string[] mUnitText = { "", "nghìn", "triệu", "tỷ", "nghìn tỷ", "triệu tỷ", "tỷ tỷ" };

            StringBuilder mTemp = new StringBuilder();
            bool needLinh = false;
            bool hasNonZeroAfterHundred = false;

            for (int i = 0; i <= mLen; i++)
            {
                int mDigit = Convert.ToInt32(sNumber[i].ToString());
                int remainingLength = mLen - i;
                int unitIndex = remainingLength / 3;
                int positionInGroup = remainingLength % 3;

                if (mDigit != 0 || (positionInGroup == 1 && needLinh))
                {
                    mTemp.Append(" ").Append(mNumText[mDigit]);
                    if (mDigit != 0 && positionInGroup == 2)
                    {
                        hasNonZeroAfterHundred = true;
                    }
                }

                if (positionInGroup == 1 && mDigit == 0 && hasNonZeroAfterHundred)
                {
                    mTemp.Append(" linh");
                    needLinh = true;
                }
                else if (positionInGroup == 1)
                {
                    needLinh = false;
                }

                if (remainingLength > 0 || positionInGroup == 0)
                {
                    switch (positionInGroup)
                    {
                        case 0:
                            if (mTemp.Length > 0)
                            {
                                mTemp.Append(" ").Append(mUnitText[unitIndex]);
                            }
                            hasNonZeroAfterHundred = false;
                            break;
                        case 2:
                            if (mDigit != 0 || hasNonZeroAfterHundred)
                            {
                                mTemp.Append(" trăm");
                            }
                            break;
                        case 1:
                            if (mDigit != 0 || needLinh)
                            {
                                mTemp.Append(" mươi");
                            }
                            break;
                    }
                }

                if (positionInGroup == 0 && remainingLength >= 3)
                {
                    string nextGroup = sNumber.Substring(i + 1, Math.Min(3, sNumber.Length - (i + 1)));
                    if (nextGroup == "000")
                    {
                        i += 3;
                    }
                }
            }

            string result = mTemp.ToString()
                .Replace("không mươi không ", "")
                .Replace("không mươi không", "")
                .Replace("không mươi ", "linh ")
                .Replace("mươi không", "mươi")
                .Replace("một mươi", "mười")
                .Replace("mươi bốn", "mươi tư")
                .Replace("linh bốn", "linh tư")
                .Replace("mươi năm", "mươi lăm")
                .Replace("mươi một", "mươi mốt")
                .Replace("mười năm", "mười lăm")
                .Replace("không trăm linh ", "không trăm ")
                .Replace("không trăm ", "");

            result = result.Trim();
            if (string.IsNullOrEmpty(result))
            {
                return "Không đồng";
            }

            result = char.ToUpper(result[0]) + result.Substring(1) + " đồng";

            if (isNegative)
            {
                result = "Âm " + result.ToLower();
            }

            return result;
        }

        // Giữ phương thức cũ để tương thích với các đoạn mã khác nếu cần
        public static string ChuyenSoSangChu(string sNumber)
        {
            if (string.IsNullOrEmpty(sNumber))
            {
                return "Không đồng";
            }

            sNumber = sNumber.Replace(",", "").Trim();
            bool isNegative = sNumber.StartsWith("-");
            if (isNegative)
            {
                sNumber = sNumber.Substring(1);
            }

            if (!decimal.TryParse(sNumber, out decimal number))
            {
                throw new ArgumentException("Đầu vào phải là một số hợp lệ.");
            }

            return ChuyenSoSangChu(number);
        }
    }
}