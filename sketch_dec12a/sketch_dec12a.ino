void setup() {
  Serial.begin(9600);
}

void loop() {
  if (Serial.available() > 0) {
    String receivedData = Serial.readStringUntil('\n');
    processAndSendData(receivedData);
  }
}

void processAndSendData(String data) {
  // Parse the received string
  int values[64];
  int count = parseString(data, values);

  // Process the data
  String processedData = processData(values, count);

  // Send the processed data back to the C# app
  Serial.println(processedData);
}

int parseString(String input, int values[]) {
  int count = 0;
  char* ptr = strtok((char*)input.c_str(), ",");
  while (ptr != NULL) {
    values[count++] = atoi(ptr);
    ptr = strtok(NULL, ",");
  }
  return count;
}

String processData(int values[], int count) {
  String result = "[PlayerWhite]\n";
  result += "PawnsLeft=" + String(values[0]) + "\n";
  result += "KingsLeft=" + String(values[1]) + "\n";
  result += "Score=" + String(values[2]) + "\n";

  result += "[PlayerBlack]\n";
  result += "PawnsLeft=" + String(values[3]) + "\n";
  result += "KingsLeft=" + String(values[4]) + "\n";
  result += "Score=" + String(values[5]) + "\n";

  result += "[Gameboard]\n";
  for (int i = 6; i < count; ++i) {
    int row = (i - 6) / 8;
    int col = (i - 6) % 8;
    result += "Cell_" + String(row) + "_" + String(col) + "=" + String(values[i]) + "\n";
  }

  return result;
}
