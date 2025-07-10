# 📘 EZInterpreter Documentation

A EZ interpreter for `.ezc` files, written in C#. This document describes how it works, supported commands, and their syntax.

---

## 📁 Table of Contents

- [Introduction](#-introduction)
- [Program Start](#-program-start)
- [Commands](#-commands)
  - [make](#-make)
  - [plus](#-plus)
  - [minus](#-minus)
  - [ask](#-ask)
  - [say](#-say)
  - [if / endif](#-if--endif)
  - [while / endwhile](#-while--endwhile)
  - [clean](#-clean)
  - [stop](#-stop)
  - [check-key](#-check-key)
  - [wait](#-wait)
  - [mark / go](#-mark--go)
  - [list](#-list)
  - [didvide](#-didvide)
- [Labels](#-labels)
- [Error Handling](#-error-handling)

---

## 🧭 Introduction

**EZInterpreter** is an interpreter for a simple scripting language called **EzCode**. Scripts are stored in `.ezc` files and executed line-by-line.

---

## ▶ Program Start

```bash
EzCode.exe <script.ezc>
```

- Accepts exactly one `.ezc` file as an argument.
- Labels are parsed before execution.
- The script runs sequentially line-by-line.

---

## 🧩 Commands

### 🛠️ make

```ezc
make variable = "value"
make counter = 5
make result = 2 + 3
```

- Creates or overwrites a variable.
- Supports basic arithmetic operations (+, -, *, /).
- Strings must be in quotes.

---

### ➕ plus

```ezc
plus counter
```

- Increases the numeric value of a variable by 1.
- If the variable doesn’t exist, it's set to `1`.

---

### ➖ minus

```ezc
minus counter
```

- Decreases the value of a variable by 1.
- If the variable doesn’t exist, it's set to `-1`.

---

### ❓ ask

```ezc
ask name
```

- Prompts user input and stores it in a variable.

---

### 🗣 say

```ezc
say "Hello world"
say name
```

- Prints a string or a variable's value to the console.

---

### 🔀 if / endif

```ezc
if counter = 5
  say "Number is 5"
endif
```

- Executes a code block if the condition is met.
- Supports: `=`, `!=`, `<`, `>`.
- Works for strings and numbers.

---

### 🔁 while / endwhile

```ezc
while counter > 0
  say counter
  minus counter
endwhile
```

- Conditional loop.
- Same operators as `if`.
- Nested `while` blocks supported.

---

### 🧼 clean

```ezc
clean
```

- Clears the console.

---

### 🛑 stop

```ezc
stop
```

- Immediately terminates the program.

---

### ⌨ check-key

```ezc
check-key enter
```

- Sets the `keypressed` variable to `true` if the specified key was pressed, otherwise `false`.

---

### ⏳ wait

```ezc
wait 1000
```

- Pauses the program for the given time in milliseconds.

---

### 🏷 mark / go

```ezc
mark start
...
go start
```

- `mark` defines a jump label.
- `go` jumps to the corresponding `mark`.

---

### 📋 list

#### Create a list:

```ezc
list make mylist
```

#### Add a value:

```ezc
list add mylist "Hello"
```

#### Remove an item by index:

```ezc
list remove mylist 0
```

#### Get an item:

```ezc
list get mylist 1 result
```

- Stores the 2nd element of `mylist` into the variable `result`.

---

### ✂ didvide

```ezc
didvide text "," 1 part
```

- Splits a string variable by a delimiter.
- Stores the item at index `1` in a new variable.

---

## 🧭 Labels

- Labels help control program flow.
- Must be defined before using `go`.
- Label names are converted to lowercase.

---

## ❗ Error Handling

- Missing `.ezc` file → warning
- Invalid syntax → line skipped
- Unknown command → warning printed with `❓`
- Faulty `while`, `if` → block skipped

---

## 📝 Example Script

```ezc
make counter = 3
while counter > 0
  say counter
  minus counter
endwhile
say "Done!"
```

---

## 👨‍💻 Author

[GHOST143](https://ghost143.de)
