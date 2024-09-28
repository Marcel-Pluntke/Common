# This is a Python file that opens a txt file and formats it

import re
import sys
import csv
import tkinter as tk
from tkinter import filedialog
#import matplotlib.pyplot as plt

def get_file_path():
    root = tk.Tk()
    root.withdraw()  # Hide the root window
    file_path = filedialog.askopenfilename(filetypes=[("Text files", "*.txt")])
    return file_path

file_path = get_file_path()

def clean_text(file_path):
    with open(file_path, 'r') as file:
        lines = file.readlines()
    new_file_path = file_path.replace('.txt', '_clean.txt')
    with open(new_file_path, 'w') as file:
        for line in lines:
            line = re.sub(r',+', ',', line)
            file.write(line)
    return new_file_path

def txt_to_csv(file_path):
    csv_file_path = file_path.replace('.txt', '.csv')
    with open(file_path, 'r') as file:
        lines = file.readlines()
    with open(csv_file_path, 'w', newline='') as csv_file:
        writer = csv.writer(csv_file)
        for line in lines:
            writer.writerow(line.strip().split(','))
    return csv_file_path

if __name__ == '__main__':
    if len(sys.argv) > 1:
        cleaned_file_path = clean_text(sys.argv[1])
    else:
        cleaned_file_path = clean_text(file_path)
        csv_file_path = txt_to_csv(cleaned_file_path)
    # print the original and the  _clean.txt file in the console
    with open(file_path, 'r') as file:
        print("Original file:")
        print(file.read())
    with open(cleaned_file_path, 'r') as file:
        print("Cleaned file:")
        print(file.read())
    
   

    