void main() {
    String[] cultureCodes = {"en-GB", "en-US", "fr-FR", "de-DE", "en-KE", "en-AU"};

    for (String code : cultureCodes) {
        // Create locale from language + country
        Locale locale = Locale.forLanguageTag(code);

        // Print separators
        String line = "-".repeat(code.length());
        System.out.println(line);
        System.out.println(locale.getDisplayName(Locale.ENGLISH));
        System.out.println(line);

        // Format months for the given locale
        DateTimeFormatter formatter = DateTimeFormatter.ofPattern("d MMM yyyy", locale);
        for (int i = 1; i <= 12; i++) {
            LocalDate date = LocalDate.of(2025, i, 1);
            System.out.println(date.format(formatter));
        }
    }

}






