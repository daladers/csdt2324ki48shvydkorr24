String mySt = "";
boolean stringComplete = false;
const char delimiter = '\n';

void setup() {
  Serial.begin(9600);
}

void loop() {
  while (Serial.available()) {
    char c = Serial.read();
    mySt += c;

    if (c == delimiter) {
      stringComplete = true;
    }
  }

  if (stringComplete) {
    Serial.print("task2 Roman Shvydko\n"); // Ensure newline character is sent
    mySt = "";
    stringComplete = false;
  }
}
