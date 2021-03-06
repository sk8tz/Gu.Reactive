﻿namespace Gu.Wpf.Reactive
{
    using System;
    using System.Globalization;
    using System.Runtime.CompilerServices;
    using System.Windows.Data;
    using System.Windows.Markup;

    using Gu.Reactive;
    using Gu.Wpf.Reactive.TypeConverters;

    /// <summary>
    /// Class implements a base for a typed value converter used as a markup extension. Override the Convert method in the inheriting class
    /// </summary>
    /// <typeparam name="TInput">Type of the expected input - value to be converted</typeparam>
    /// <typeparam name="TResult">Type of the result of the conversion</typeparam>
    [MarkupExtensionReturnType(typeof(IValueConverter))]
    public abstract class MarkupConverter<TInput, TResult> : MarkupExtension, IValueConverter
    {
        private static readonly ITypeConverter<TInput> InputTypeConverter = TypeConverterFactory.Create<TInput>();
        private static readonly ITypeConverter<TResult> ResultTypeConverter = TypeConverterFactory.Create<TResult>();

        protected MarkupConverter()
        {
        }

        object IValueConverter.Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            this.VerifyValue(value, parameter);
            if (InputTypeConverter.IsValid(value))
            {
                var convertTo = InputTypeConverter.ConvertTo(value, culture);
                return this.Convert(convertTo, culture);
            }
            return this.ConvertDefault();
        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            this.VerifyValue(value, parameter);
            if (ResultTypeConverter.CanConvertTo(value, culture))
            {
                var convertTo = ResultTypeConverter.ConvertTo(value, culture);
                return this.ConvertBack(convertTo, culture);
            }
            return this.ConvertBackDefault();
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }

        protected abstract TResult Convert(TInput value, CultureInfo culture);

        protected virtual TResult ConvertDefault()
        {
            return default(TResult);
        }

        protected abstract TInput ConvertBack(TResult value, CultureInfo culture);

        protected virtual TInput ConvertBackDefault()
        {
            return default(TInput);
        }

        private void VerifyValue(object value, object parameter, [CallerMemberName] string caller = null)
        {
            if (DesignMode.IsDesignTime)
            {
                if (parameter != null)
                {
                    var message = $"ConverterParameter makes no sense for MarkupConverter. Parameter was: {parameter} for converter of type {this.GetType().Name}";
                    throw new ArgumentException(message);
                }

                if (!InputTypeConverter.IsValid(value))
                {
                    var message = $"{caller} value: {value}{(value != null ? "of type: " + value.GetType().Name : string.Empty)} is not valid for converter of type: {this.GetType().Name} from: {typeof(TInput).PrettyName()} to {typeof(TResult).PrettyName()}";
                    throw new ArgumentException(message, nameof(value));
                }
            }
        }
    }
}
