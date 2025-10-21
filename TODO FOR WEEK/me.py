import tkinter as tk
from tkinter import messagebox, ttk
import threading
import time
import json
import os
import winsound  # للتنبيه الصوتي على ويندوز

TASKS_FILE = "tasks.json"
tasks = []

# تحميل المهام من الملف
def load_tasks():
    global tasks
    if os.path.exists(TASKS_FILE):
        with open(TASKS_FILE, "r", encoding="utf-8") as f:
            try:
                tasks = json.load(f)
            except json.JSONDecodeError:
                tasks = []
        for t in tasks:
            if 'progress' not in t:
                t['progress'] = 0
            if 'study_time' not in t:
                t['study_time'] = 0  # دقائق الدراسة الكلية
        update_task_list()

# حفظ المهام في الملف
def save_tasks():
    with open(TASKS_FILE, "w", encoding="utf-8") as f:
        json.dump(tasks, f, ensure_ascii=False, indent=4)

def add_task():
    day = day_combobox.get()
    task = task_entry.get()
    progress = progress_entry.get()
    if day and task:
        progress_value = int(progress) if progress.isdigit() and 0 <= int(progress) <= 100 else 0
        tasks.append({"day": day, "task": task, "progress": progress_value, "study_time": 0})
        update_task_list()
        save_tasks()
        task_entry.delete(0, tk.END)
        progress_entry.delete(0, tk.END)
    else:
        messagebox.showwarning("تنبيه", "الرجاء إدخال المهمة واختيار اليوم")

def update_task_list():
    task_listbox.delete(0, tk.END)
    for t in tasks:
        task_listbox.insert(tk.END, f"{t['day']} - {t['task']} | التقدّم: {t['progress']}% | دقائق دراسة: {t['study_time']}")

def update_progress():
    selected = task_listbox.curselection()
    if not selected:
        messagebox.showwarning("تنبيه", "اختر مهمة لتحديث التقدّم")
        return
    new_progress = progress_entry.get()
    if not new_progress.isdigit() or not (0 <= int(new_progress) <= 100):
        messagebox.showwarning("تنبيه", "ادخل قيمة صحيحة بين 0 و100")
        return
    task_index = selected[0]
    tasks[task_index]['progress'] = int(new_progress)
    update_task_list()
    save_tasks()
    progress_entry.delete(0, tk.END)

def delete_task():
    selected = task_listbox.curselection()
    if not selected:
        messagebox.showwarning("تنبيه", "اختر مهمة لحذفها")
        return
    task_index = selected[0]
    task_name = tasks[task_index]['task']
    confirm = messagebox.askyesno("تأكيد الحذف", f"هل تريد حذف المهمة: {task_name}؟")
    if confirm:
        tasks.pop(task_index)
        update_task_list()
        save_tasks()

def start_timer():
    selected = task_listbox.curselection()
    if not selected:
        messagebox.showwarning("تنبيه", "اختر مهمة لتشغيل المؤقت")
        return
    minutes = timer_entry.get()
    if not minutes.isdigit() or int(minutes) <= 0:
        messagebox.showwarning("تنبيه", "ادخل مدة المؤقت بالدقائق صحيحة")
        return
    task_index = selected[0]
    task_name = tasks[task_index]['task']
    minutes = int(minutes)

    threading.Thread(target=run_timer, args=(task_index, task_name, minutes), daemon=True).start()

def run_timer(task_index, task_name, minutes):
    total_seconds = minutes * 60
    for i in range(total_seconds, 0, -1):
        mins, secs = divmod(i, 60)
        timer_label.config(text=f"المهمة: {task_name} | الوقت المتبقي: {mins} دقيقة {secs} ثانية")
        time.sleep(1)
    # تحديث دقائق الدراسة للمهمة
    tasks[task_index]['study_time'] += minutes
    update_task_list()
    save_tasks()
    timer_label.config(text=f"انتهى الوقت للمهمة: {task_name} ✅")
    winsound.Beep(1000, 500)
    messagebox.showinfo("انتهى الوقت", f"انتهى المؤقت للمهمة: {task_name} | أضيفت {minutes} دقيقة للدراسة")

# إعداد نافذة البرنامج
root = tk.Tk()
root.title("مهام أسبوعية مع مؤقت بالدقائق وتسجيل الوقت")
root.geometry("700x450")

# اختيار اليوم
tk.Label(root, text="اليوم:").grid(row=0, column=0, padx=5, pady=5)
day_combobox = ttk.Combobox(root, values=["الأحد","الاثنين","الثلاثاء","الأربعاء","الخميس","الجمعة","السبت"])
day_combobox.grid(row=0, column=1, padx=5, pady=5)

# إدخال المهمة
tk.Label(root, text="المهمة:").grid(row=1, column=0, padx=5, pady=5)
task_entry = tk.Entry(root, width=30)
task_entry.grid(row=1, column=1, padx=5, pady=5)

# إدخال مقدار التقدّم
tk.Label(root, text="التقدّم (%):").grid(row=2, column=0, padx=5, pady=5)
progress_entry = tk.Entry(root, width=10)
progress_entry.grid(row=2, column=1, padx=5, pady=5)

# أزرار الإضافة والتحديث والحذف
tk.Button(root, text="إضافة مهمة", command=add_task).grid(row=0, column=2, rowspan=2, padx=10)
tk.Button(root, text="تحديث التقدّم", command=update_progress).grid(row=2, column=2, padx=10)
tk.Button(root, text="حذف المهمة", command=delete_task).grid(row=3, column=2, padx=10)

# قائمة المهام
task_listbox = tk.Listbox(root, width=80)
task_listbox.grid(row=3, column=0, columnspan=2, pady=10)

# مؤقت بالدقائق
tk.Label(root, text="مدة المؤقت (دقائق):").grid(row=4, column=0)
timer_entry = tk.Entry(root)
timer_entry.grid(row=4, column=1)
tk.Button(root, text="تشغيل المؤقت", command=start_timer).grid(row=4, column=2)

timer_label = tk.Label(root, text="المؤقت متوقف")
timer_label.grid(row=5, column=0, columnspan=3, pady=10)

# تحميل المهام عند بدء البرنامج
load_tasks()

root.mainloop()
