namespace KMBrigadeiria.Resources
{
    public static class StringMessages
    {
        #region EntityNotFoundException Messages
        public static readonly string ENTITY_NOT_FOUND = "A entidade buscada não foi encontrada.";
        public static readonly string ADDRESS_NOT_FOUND = "O endereço buscado não foi encontrado.";
        public static readonly string CLIENT_NOT_FOUND = "O cliente buscado não foi encontrado.";
        #endregion

        #region InvalidAddressIdException Messages
        public static readonly string INVALID_ADDRESS_ID = "O endereço que esta tentando manipular não pertence a este cliente.";
        #endregion

        #region AddressInexistentException Messages
        public static readonly string ADDRESS_INEXISTENT = "O endereço que esta tentando excluir não esta cadastrado.";
        #endregion

        #region ClientAlreadyHaveAddressException Messages
        public static readonly string CLIENT_ALREADY_HAVE_ADDRESS = "O cliente já possui um endereço cadastrado.";
        #endregion

        #region ValidIdAttribute Messages
        public static readonly string INVALID_ID_ATTRIBUTE = "A entidade passada não existe.";
        #endregion
    }
}
