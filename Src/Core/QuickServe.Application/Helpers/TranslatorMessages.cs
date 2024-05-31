using QuickServe.Application.DTOs;
using QuickServe.Domain.Ingredients.Entities;
using QuickServe.Domain.News.Entities;
using QuickServe.Domain.Products.Entities;

namespace QuickServe.Application.Helpers
{
    public static class TranslatorMessages
    {
        public static class AccountMessages
        {
            public static TranslatorMessageDto Account_notfound_with_UserName(string userName) => new(nameof(Account_notfound_with_UserName), [userName]);
            public static TranslatorMessageDto Username_is_already_taken(string userName) => new(nameof(Username_is_already_taken), [userName]);
            public static string Invalid_password() => nameof(Invalid_password);
            public static string Unauthorized() => new(nameof(Unauthorized));
            public static TranslatorMessageDto Account_already_exist_with_Email(string email) => new(nameof(Account_already_exist_with_Email), [email]);
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
        public static class IngredientTypeMessages
        {
            public static TranslatorMessageDto IngredientType_not_Found_with_id(long id)
                => new(nameof(IngredientType_not_Found_with_id), [id.ToString()]);
            public static TranslatorMessageDto IngredientType_exists_ingredient_with_id(long id)
                => new(nameof(IngredientType_exists_ingredient_with_id), [id.ToString()]);
            public static TranslatorMessageDto IngredientType_name_existed_with_name(string name)
                => new(nameof(IngredientType_name_existed_with_name), [name]);
        }
       
        public static class IngredientMessages
        {
            public static TranslatorMessageDto Ingredient_not_Found_with_id(long id)
                => new(nameof(Ingredient_not_Found_with_id), [id.ToString()]);
            public static TranslatorMessageDto Ingredient_exists_between_product_and_session_with_id(long id)
                => new(nameof(Ingredient_exists_between_product_and_session_with_id), [id.ToString()]);
            public static TranslatorMessageDto Ingredient_name_existed_with_name(string name)
                => new(nameof(Ingredient_name_existed_with_name), [name]);
        }

        public static class ProductTemplateMessages
        {
            public static TranslatorMessageDto ProductTemplate_not_found_with_id(long id)
                => new(nameof(ProductTemplate_not_found_with_id), [id.ToString()]);
            public static TranslatorMessageDto ProductTemplate_name_existed_with_name(string name)
               => new(nameof(ProductTemplate_name_existed_with_name), [name]);
            public static TranslatorMessageDto ProductTemplate_existed_inative_step(long id)
              => new(nameof(ProductTemplate_existed_inative_step), [id.ToString()]);
            public static TranslatorMessageDto ProductTemplate_exists_products_and_templatesteps(long id)
                => new(nameof(ProductTemplate_exists_products_and_templatesteps), [id.ToString()]);
        }
        public static class TemplateStepMessages
        {
            public static TranslatorMessageDto TemplateStep_not_found_with_id(long id)
                => new(nameof(TemplateStep_not_found_with_id), [id.ToString()]);
            public static TranslatorMessageDto TemplateStep_existed_with_name(string name)
               => new(nameof(TemplateStep_existed_with_name), [name]);
            public static TranslatorMessageDto TemplateStep_existed_ingredienttype_templatestep(long id)
               => new(nameof(TemplateStep_existed_ingredienttype_templatestep), [id.ToString()]);
        }
    }
}
