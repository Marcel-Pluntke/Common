// Definiere die Pins für die Kanäle und PWM-Ausgabe
const int channel1Pin = 2;  // Links/Rechts (nicht verwendet)
const int channel2Pin = 3;  // Vor/Zurück
const int pwmForwardPin = 9;  // PWM-Ausgabe für Vorwärtsbewegung
const int pwmBackwardPin = 10; // PWM-Ausgabe für Rückwärtsbewegung

// Variablen zum Speichern der Pulsbreite
unsigned long channel2Value = 0;
int currentForwardPWM = 0; // Aktueller PWM-Wert für Vorwärts
int currentBackwardPWM = 0; // Aktueller PWM-Wert für Rückwärts

// Sanfte Regelungskonstante
const int smoothFactor = 5; // Je höher der Wert, desto langsamer die Anpassung (1 = sofortige Anpassung)

void setup() {
  // Setze die Pins als Eingänge
  pinMode(channel1Pin, INPUT); // Falls erforderlich, sonst entfernen
  pinMode(channel2Pin, INPUT);
  
  // Setze die Pins als Ausgänge
  pinMode(pwmForwardPin, OUTPUT);
  pinMode(pwmBackwardPin, OUTPUT);
  
  // Starte die serielle Kommunikation
  Serial.begin(9600);
}

void loop() {
  // Lese die Pulsbreite in Mikrosekunden
  channel2Value = pulseIn(channel2Pin, HIGH);

  // Steuerlogik für Vorwärts, Rückwärts und Neutral
  int targetForwardPWM = 0;   // Ziel-PWM-Wert für Vorwärts
  int targetBackwardPWM = 0;  // Ziel-PWM-Wert für Rückwärts

  if (channel2Value > 1700) {
    // Vorwärtsgang
    targetForwardPWM = map(channel2Value, 1700, 1967, 0, 170);
    targetBackwardPWM = 0; // Rückwärts aus
  } else if (channel2Value < 1300) {
    // Rückwärtsgang
    targetBackwardPWM = map(channel2Value, 1300, 988, 0, 170);
    targetForwardPWM = 0; // Vorwärts aus
  } else {
    // Neutralgang
    targetForwardPWM = 0;
    targetBackwardPWM = 0;
  }

  // Sanfte Anpassung der PWM-Werte
  if (targetForwardPWM == 0 && targetBackwardPWM == 0) {
    // Wenn im Neutralgang, setze beide PWM-Werte sofort auf 0
    currentForwardPWM = 0;
    currentBackwardPWM = 0;
  } else {
    // Sonst sanfte Anpassung
    currentForwardPWM = currentForwardPWM + (targetForwardPWM - currentForwardPWM) / smoothFactor;
    currentBackwardPWM = currentBackwardPWM + (targetBackwardPWM - currentBackwardPWM) / smoothFactor;
  }

  // PWM-Signale ausgeben
  analogWrite(pwmForwardPin, currentForwardPWM);
  analogWrite(pwmBackwardPin, currentBackwardPWM);

  // Serielle Ausgabe zur Überwachung
  Serial.print("Kanal 2 (Vor/Zurück): ");
  Serial.print(channel2Value);
  Serial.print("   PWM Vorwärts: ");
  Serial.print(currentForwardPWM);
  Serial.print("   PWM Rückwärts: ");
  Serial.println(currentBackwardPWM);

  // Kurze Pause, um die Ausgabe lesbar zu machen
  delay(100);
}
