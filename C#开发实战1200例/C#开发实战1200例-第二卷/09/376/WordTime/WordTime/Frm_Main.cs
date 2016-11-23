using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WordTime
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            //声明字符串
            string text = @"var query = from info in infoList 
    where info.AuditFlag == null || info.AuditFlag == false 
    join emp in empList 
       on info.SaleMan equals emp.EmployeeCode 
    join house in houseList 
       on info.WareHouse equals house.WareHouseCode 
    join client in clientList 
       on info.ClientCode equals client.ClientCode 
    join dictPayMode in dictList 
       on info.PayMode equals dictPayMode.ValueCode 
    where dictPayMode.TypeCode == 'PayMode\' 
    join dictInvoiceType in dictList 
       on info.InvoiceType equals dictInvoiceType.ValueCode 
    where dictInvoiceType.TypeCode == 'InvoiceType'
    select new 
    { 
       id = info.ID,
       SaleBillCode = info.SaleBillCode,
       SaleMan = emp.Name,
       SaleDate = info.SaleDate,
       Provider = client.ShortName,
       WareHouse = house.ShortName,
       PayMode = dictPayMode.ValueName,
       InvoiceType = dictInvoiceType.ValueName,
       InvoiceCode = info.InvoiceCode,
       AuditFlag = info.AuditFlag 
    };";
            //按单词转换为数组
            string[] allWords = text.Split(new char[] { '.', '?', '!', ' ', ';', ':', ',' }, StringSplitOptions.RemoveEmptyEntries);
            string[] distinctWords = allWords.Distinct().ToArray<string>();//去掉单词数组中重复的单词
            int[] counts = new int[distinctWords.Length];//创建一个存放词频统计信息的数组
            for (int i = 0; i < distinctWords.Length; i++)//遍历每个单词
            {
                string tempWord = distinctWords[i];
                //计算每个单词出现的次数
                var query = from item in allWords
                            where item.ToLower() == tempWord.ToLower()
                            select item;
                counts[i] = query.Count();
            }
            //输出词频统计结果
            for (int i = 0; i < counts.Count(); i++)
            {
                label1.Text+=distinctWords[i] + "出现 " + counts[i].ToString() + " 次\n";
            }
        }
    }
}
