import xlrd
from collections import OrderedDict
import json
import codecs

convert_list = []
level_excel = xlrd.open_workbook('garbage.xlsx')
level_sheet = level_excel.sheet_by_index(0)
garbage_sheet = level_excel.sheet_by_index(1)
excel_list = [level_sheet, garbage_sheet]
convert_list = []
for i in range(0, len(excel_list)):
    single_list = []
    title = excel_list[i].row_values(0)
    for rownum in range(3, excel_list[i].nrows):
        rowvalue = excel_list[i].row_values(rownum)
        if rowvalue[0] == '__END__':
            convert_list.append(single_list)
            break
        single = OrderedDict()
        for colnum in range(0, len(rowvalue)):
            if(title[colnum] == '__END__'):
                single_list.append(single)
                break
            single[title[colnum]] = rowvalue[colnum]
j = json.dumps(convert_list)

with codecs.open('0.json',"w","utf-8") as f:
    f.write(j)
