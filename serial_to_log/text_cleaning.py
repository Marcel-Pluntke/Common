#this is an python file that  opens a txt file and formates it

# for example the text line is like "2019-01-01 00:00:00,000 ,,,,,,,20,34.4,23,4" the goal output would be "2019-01-01 00:00:00,000 ,20,34.4,23,4" so remove all the uses ","

import re
import sys
import csv

file_path = '/home/marcel/Dokumente/Projects/serial_to_log/Test.txt'

def clean_text(file_path):
    with open(file_path, 'r') as file:
        lines = file.readlines()
    new_file_path = file_path.replace('.txt', '_clean.txt')
    with open(new_file_path, 'w') as file:
        for line in lines:
            line = re.sub(r',+', ',', line)
            file.write(line)
    return new_file_path

#convert the cleaned txt file to a csv file

def txt_to_csv(file_path):
    with open(file_path, 'r') as file:
        lines = file.readlines()
    with open(file_path.replace('.txt', '.csv'), 'w') as file:
        writer = csv.writer(file)
        for line in lines:
            writer.writerow(line.strip().split(','))
 

# if __name__ == '__main__':
clean_text(file_path)
txt_to_csv(file_path)

#open the txt file s  that the user can check the output
with open(file_path, 'r') as file:
    print(file.read())
#open the text file cleaned
with open(file_path.replace('.txt', '_clean.txt'), 'r') as file:
    print(file.read())





"""
    if len(sys.argv) > 1:
        clean_text(sys.argv[1])
    else:
        clean_text(file_path)

    if len(sys.argv) > 1:
        txt_to_csv(sys.argv[1])
    else:
        txt_to_csv(file_path)
    """




