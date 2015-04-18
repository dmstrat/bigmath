# Introduction #

This is where we talk about the Add Method's Implementation.

Process:
Take two strings for your numbers to add
Convert them to our structure
Perform simple addition
Convert that result into a string as your answer.



# Details #

Adding seems simple when you do it on paper, but when you think about it, you have to do a lot of actions to complete a multiple digit number to a multiple digit number addition but it is repeatable.

Let's talk about adding in it's simplest terms. Adding 123 to 999
```
   1 2 3  first number
+  9 9 9  second number
--------
          answer 
```
Adding 9 + 3 gives us 12, but now we're stuck with a new concept already, carry over.

Now we have
```
     1    carry over
   1 2 3  first number
+  9 9 9  second number
--------
       2  answer 
```
continuing on in a repeating fashion we get:
```
 1 1 1    carry over
   1 2 3  first number
+  9 9 9  second number
--------
 1 1 2 2  answer 
```
As you can probably see, we're finding a pattern here and realizing what we need.  4 lists: first number, second number, carry over, and answer.

What about when the length of the numbers don't match?
```
   1 1    carry over
   1 2 3  first number
+    9 9  second number
--------
   2 2 2  answer 
```
This is where we can introduce the concept of leading zeros.  It doesn't change the problem but "squares up" the math to easily repeat over a known limit.

Now we have this:
```
 0 1 1 0  carry over
 0 1 2 3  first number
+0 0 9 9  second number
--------
   2 2 2  answer 
```
You may notice the carry over of the zero in the ones column, but again, it isn't effecting the answer because adding zero never changes the value in addition.

Now we can loop through each column, using an index, carrying over to the next index number's carry over list until you reach the end.

You'll never have anything larger than 9 + 9 + 1 (from carryover) since you're only doing one column at a time. Therefore, your worst case is your last column is 0 + 0 + 1 (from carryover) like this:
```
 1 1 1 0  carry over
 0 9 9 9  first number
+0 9 9 9  second number
--------
 1 9 9 8  answer 
```
Now that we have this in a list and can make easy addition we've got our answer and can return that number after converting it back to a string.

# Performing the math #

  1. determine which number is larger, putting that as the topNumber with other number being bottomNumber
  1. add leading zeros to match length of larger number plus 1
    1. example: 123 + 99 would be 0123 + 0099
  1. create your carry over and answer lists
  1. looping from ones column [index:0] to most significant digit column  including leading zero column:
    1. add carry over, topNumber, and bottomNumber at this index
    1. if any carry over, place in index+1 carry over
    1. put remaining answer in answer at this index.
  1. convert answer back to a string for return to caller