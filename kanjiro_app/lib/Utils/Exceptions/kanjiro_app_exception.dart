class KanjiroAppException implements Exception {
  KanjiroAppException({required this.message});

  final String message;

  @override
  String toString() {
    return 'Erro do App: $message';
  }
}
