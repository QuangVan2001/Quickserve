using QuickServe.Application.DTOs;
using QuickServe.Domain.News.Entities;

namespace QuickServe.Application.Helpers
{
    public static class TranslatorMessages
    {
        public static class AccountMessages
        {
            public static TranslatorMessageDto Account_notfound_with_UserName(string userName) => new(nameof(Account_notfound_with_UserName), [userName]);
            public static TranslatorMessageDto Username_is_already_taken(string userName) => new(nameof(Username_is_already_taken), [userName]);
            public static string Invalid_password() => nameof(Invalid_password);
        }
        public static class ProductMessages
        {
            public static TranslatorMessageDto Product_notfound_with_id(long id)
                => new(nameof(Product_notfound_with_id), [id.ToString()]);
        }
        
        public static class StoreMessages
        {
            public static TranslatorMessageDto Store_notfound_with_id(long id)
                => new(nameof(Store_notfound_with_id), [id.ToString()]);
        }

        public static class CategoryMessages
        {
            public static TranslatorMessageDto Category_not_Found_with_id(long id)
                => new(nameof(Category_not_Found_with_id), [id.ToString()]);
            public static TranslatorMessageDto Category_exists_product_templates_with_id(long id)
                => new(nameof(Category_exists_product_templates_with_id), [id.ToString()]);
            public static TranslatorMessageDto Category_name_existed_with_name(string name)
                => new(nameof(Category_name_existed_with_name), [name]);
        }

        public static class ProductTemplateMessages
        {
            public static TranslatorMessageDto ProductTemplate_not_found_with_id(long id)
                => new(nameof(ProductTemplate_not_found_with_id), [id.ToString()]);
        }
    }
}
