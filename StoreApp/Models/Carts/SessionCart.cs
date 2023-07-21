using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using StoreApp.Extensions;
using StoreApp.Models.Product;

namespace StoreApp.Models.Carts
{
    public class SessionCart : Cart
    {
        [JsonIgnore]
        public ISession? Session { get; set; }

        public static Cart GetCart(IServiceProvider services)
        {
            ISession? session = services.GetRequiredService<IHttpContextAccessor>()
                .HttpContext?.Session;

            SessionCart cart = session?.GetModel<SessionCart>("cart") ?? new SessionCart();
            cart.Session = session;
            return cart;
        }

        public override void AddItem(ProductForCartViewModel product, int quantity)
        {
            base.AddItem(product, quantity);
            Session?.SetModel<SessionCart>("cart", this);
        }

        public override void Clear()
        {
            base.Clear();
            Session?.Remove("cart");
        }

        public override void RemoveLine(ProductForCartViewModel product)
        {
            base.RemoveLine(product);
            Session?.SetModel<SessionCart>("cart", this);
        }
    }
}