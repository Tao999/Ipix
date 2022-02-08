
# Ipix cahier des charges
 - Instructions simples (arguments limités)
 - Variables (full string) (pas de système de portée)
 - Label
 - Condition
 - Rester simple


# Instructions


## Opérateurs
 - [x] `add <var1> <var2> <var3>` -> Assigne à "var1" : "var2" + "var3"
 - [x] `sub <var1> <var2> <var3>` -> Assigne à "var1" : "var2" - "var3"
 - [x] `mul <var1> <var2> <var3>` -> Assigne à "var1" : "var2" * "var3"
 - [x] `div <var1> <var2> <var3>` -> Assigne à "var1" : "var2" / "var3"

## Sauts
 - [x] `:<label>` -> Déclare un label
 - [x] `goto <label>` -> Va à la ligne "label"
 - [x] `equ <label> <var1> <var2>` -> Si "arg1" == "arg2" alors goto "label"
 - [x] `sup <label> <var1> <var2>` -> Si "arg1" > "arg2" alors goto "label"
 - [x] `esp <label> <var1> <var2>` -> Si "arg1" >= "arg2" alors goto "label"

## Système
 - [x] `set <varName> <value>` -> Assigne "value" à la variable "varName"
 - [x] `print <var>` -> Affiche la valeur retournée par "arg"
 - [x] `end` -> Stop le programme.

# Fonctionnement
Interpreteur :
- Instructions : Stock toutes les instructions
- vars : Stock toutes les variables
- labels : Stock toutes les positions des labels
- linePointer : File pointer
- status : Décide de l'état du programme