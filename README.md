# CSVSplitter+
## Generell
CSV-Splitter+ ist ein Programm zum Teilen/Konvertieren von CSV-Dateien.
Für einen möglichst großen Anwendungsbereich steht es als Windows und
Konsolenversion zur Verfügung.

In der Version 1.2 wurden wesentliche Kernkomponenten neu geschrieben.
Dies bringt etliche neue Funktionen mit sich. Bisher wurde das CSV-File
einfach Zeilenweise gelesen und verarbeitet.

Mit dem neuen Programmkern wird das CSV-File nun Spaltenweise verarbeitet.
Dadurch ist es nun möglich folgende Funktionen zu realisieren.
* CSV File spaltenweise splitten
* In einem CSV File die Spalten zu sortieren
* CSV File spaltenweise und zeilenweise splitten
* Die CSV-Optionen wie Spaltentrennzeichen zu ändern
* Die CSV-Optionen wie Textbrgrenzungszeichen zu ändern
* Die CSV-Optionen wie Zeilenumbruch zu ändern.
  Zeilenumbrüche als Inhalt in Textfeldern bleiben dabei
  unverändert.
## Versionen 
Das Programm steht in zwei Versionen zur Verfügung. Für eine manuelle 
Bearbeitung gibt es eine Windowsversion, die mit der Maus bedient wird.
Für eine Verwendung im Rahmen einer automatischen Verarbeitung von Datenfiles
gibt es eine Konsolenversion. Diese ermöglicht die Verwendung in Batchfiles bzw.
in der Konsole. Beide Versionen verfügen über den gleichen Befehlsumfang.
## Windowsversion
Für die Windowsversion starten sie die Datei "CSVSplitter.exe".
## Konsolenversion
Die Konsolenversion steht als "CSVSplitter_cli.exe" zu Verfügung.
### Konsolenparameter:
| Flag | alternative            | required | default | description|
| ---- | ---------------------- | -------- | ------- | -----------|
| -i   | --inputFile            | ja       |         | Quelldatei|
| -l   | --lineNumber           |          | 10000   | Teile nach Zeilen.|
| -s   | --sourceHeader         |          | False   | Quelle enthält Spaltenüberschriften|
| -t   | --targetHeader         |          | False   | Schreibt Spaltenüberschriften in Zieldateien. !Ignoriert falls -s nicht definiert.|
| -c   | --sourceTextDelimiter  |          | "       | Textbegrenzer in Quelle.|
| -m   | --sourceLineDelimiter  |          | \r\n    | Zeilenumbruch in Quelle.|
| -f   | --sourceFieldDelimiter |          | ;       | Spaltentrenner in Quelle.|
| -d   | --sourcePrefix         |          | 0       | Anzahl von prefixzeilen.|
| -n   | --targetTextDelimiter  |          | -t      | Textbegrenzer in Zieldatei.|
| -o   | --targetLineDelimiter  |          | -m      | Zeilenumbruch in Zieldatei.|
| -p   | --targetFieldDelimiter |          | -f      | Spaltentrenner in Zieldatei.|
| -g   | --targetPrefix         |          | False   | Schreibt Prefixzeilen in Zieldateien.|
| -j   | --indices:[i or h]     |          |         | i - Spalten sind mittels Spaltennummer definiert..<br> h - Spalten sind mittels Spaltenüberschriften definiert.|
| -e   | --exportHeader         |          |         | Spalten, sie in Zieldatei geschrieben werden sollen [csv - data].|
| -b   | --splitBefore          |          |         | Ein String, der die Teilungskriterien enthält.<br>Die Quelldatei wird VOR der Zeile getrennt, die den Kriterien entspricht.|
| -a   | --splitAfter           |          |         | Ein String, der die Teilungskriterien enthält.<br>Die Quelldatei wird NACH der Zeile getrennt, die den Kriterien entspricht. !Ignoriert falls -b definiert.|
                                             
Die Exportheader(Parameter -e) sind in folgender Form zu definieren:
1. Es dürfen keine Textbegrenzer verwendet werden.
2. Als Spaltentrenner ist ein ;(Semikolon) zu verwenden.
3. In den Spaltenüberschriften dürfen keine Zeilenumbrüche vorkommen.
4. Es dürfen keine Leerzeichen in den Spaltenüberschriften vorkommen.

Es gibt zwei Parameter in denen Spalten referenziert werden. Einerseits der 
Parameter -e|--exportheader und andererseits -b|--splitBefore oder
-a|--splitAfter. Die Spalten müssen entweder über ihren Index beginend bei 0
oder mittels der Spaltenüberschrift referenziert werden. Die Form darf nicht
gemischt werden. Es ist also NICHT möglich im Parameter -e den Index zu 
verwenden und im Parameter -b den Spaltennamen. Der Anwender muss sich für 
eine Form entscheiden und diese mit dem Parameter -j|--indices angeben.

## Spaltenauszug - Sortieren - Spaltenweise trennen
Ab der Version1.2 werden CSV-Files spaltenweise verarbeitet. Dadurch ist es 
möglich nur gewisse Spalten in die neue Datei zu schreiben. Ebenso kann man 
deren Reihenfolge festlegen. Dadurch können CSV-Files umsortiert, bzw. 
spaltenweise getrennt werden. Die Spaltenangabe kann durch Angabe des 
Spaltennamens, oder des Index(0-basierend) erfolgen. Die Form der Spaltenangabe
wird über den Kommandozeilenparameter !!!-index!!! definiert.

Eine Umsortierung  erfolgt in der Form, dass man einfach alle Spalten in der 
gewünschten Reihenfolge angibt.

Beispiel Sortierung:
In unserem Datenfile liegen die Spalten wie folgt:

Zeilenschlüssel;Kundennummer;Telefonnummer;Kundenname

Möchte man die Spalten umsortieren, damit der Kundenname nach der Kundennummer 
folgt, sind einfach alle Spalten in der gewünschen Reihenfolge anzugeben:

Zeilenschlüssel;Kundennummer;Kundenname;Telefonnummer

Beispiel Trennung:
Ein spaltenweises Trennung erfolgt durch eine zweimaligen Auszug der jeweils 
gewünschen Spaltengruppen

Wir möchten ein Datei mit den Spalten Zeilenschlüssel;Kundennummer;Kundenname 
und ein zweiten File mit den Spalten Kundennummer;Telefonnummer

## Teilungskriterien
Die Kriterien für die zeilenweise Teilung können spaltenbezogen definiert werden
und UND- oder ODER-Verknüpft werden. So lassen sich komplexe Szenarien
realisieren.

Die Kriterien werden in Blöcken, die Oder-Verknüpft sind definiert. Jeder Block 
kann aus mehreren Kriterien, die UND-Verknüpft sind, bestehen. Jedes einzelne 
Kriterium besteht aus der Angabe der Spalte und einem Regulären Ausdruck, dem 
der Zelleninhalt entsprechen soll.

Der Logische Aufbau sieht daher wie folgt aus:
```(
   (spalte1|20)
   AND
   (spalte2|50)
)
OR
(
   (Spalte1|20)
   AND
   (Spalte2|60)
)
```

In diesem Beispiel wird das File an den Zeilen getrennt, in denen die Spalte 
"Spalte1" den Wert "20" enthält und die Spalte "Spalte2" entweder "50" oder "60". 

In der Praxis entfällt die Angabe von AND und OR. Weiters werden die runden 
Klammern durch spitze ersetzt. Das obige Beispiel sieht daher folgendermaßen aus:

```
<
  <spalte1|Kriterium>
  <spalte2|kriterium>
>
<
  <spalte1|kriterium>
  <spalte2|kriterium>
>
```

Für die Spalte kann entweder der Spaltenname oder der Index(0-basierend) 
angegeben werden. Dieses Vorgehen muß mit dem Kommandozeilenparameter für den 
Indextyp übereinstimmen.

Spitzen schließenden Klammern, die im Kriteriumausdruck verwendet werden, müssen
ein Backslash vorangestellt werden. Andernfalls würde diese Klammer als Ende 
des Ausdruckes erkannt werden.

Eine anders gestaltete Und/Oder-Verknüpfung wird nicht unterstützt!

Die minimale Form, in der nur eine Spalte nach einem Wert ausgewertet wird,
sieht folgendermaßen aus: <<spalte1|20>>

## Präfix
Präfixzeilen sind Zeilen am Dateianfang, die vor dem eigentlichen Datenbereich 
stehen. Die Headerzeile ist als Spaltenüberschriften Teil des Datenblockes und
gehört nicht zum Präfix.

Mit dem Parameter --sourcePrefix wird definiert aus wievielen Zeilen der 
Präfixblock besteht.

Der Parameter --targetPrefix gibt an, ob die Präfixzeilen in die Teildateien 
geschrieben werden sollen.

## Veröffentlichungen
### 1.2.3 - April 2024
* Der Quellcode wird auf github zu Verfügung gestellt.

### 1.2.3 - 10. Mai 2020
* GUI-Version ist ein Frontend für das Konsolenprogramm.
* Das Konsolenprogramm legt im Falle eines Fehlers ein Logfile an, 
  welches die Analyse erleichter.

### 1.2.2 - 17. August 2018
* Verwaltung von Prefixzeilen hinzugefügt.

### 1.2.1 - 10. Juli 2018
* In der Zieldatei wird der Textbegrenzer nur mehr hinzugefügt, wenn er erforderlich ist.
  a) Wenn der textbegrenzer Teil des Zelleninhaltes ist.
  b) Wenn der spaltentrenner Teil des Zelleninhaltes ist.

### 1.2.0 - 01. Juli 2018
* Kernkomponenten neu geschrieben.
* Für Quell/Zieldatei sind Text/Spalten/Zeilendelimiter separat definierbar.
* Es können einzelne Spalten in die Zieldatei geschrieben werden.
* In den Teilungskriterien können Spalten referenziert werden.
* Einzelne Teilungskriterien können UND/ODER-Verknüpft werden.

### 1.0.6 - 19. Juli 2017
* Behebung von Fehler bei der Verarbeitung von Dateiel mit mehr als 16,7
  Millionen Datensätzen.

### 1.0 - 17. Juli 2016
* Erste Version veröffentlicht.
