﻿using System;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media.Animation;

namespace AppStudio.Uwp
{
    public static class AnimationExtensions
    {
        public static Storyboard AnimateX(this FrameworkElement element, double x, double duration = 250, EasingFunctionBase easingFunction = null)
        {
            if (element.GetTranslateX() != x)
            {
                return AnimateDouble(element, "TranslateX", element.Width, x, duration, easingFunction);
            }
            return null;
        }
        public static async Task AnimateXAsync(this FrameworkElement element, double x, double duration = 250, EasingFunctionBase easingFunction = null)
        {
            if (element.GetTranslateX() != x)
            {
                await AnimateDoubleAsync(element, "TranslateX", element.Width, x, duration, easingFunction);
            }
        }

        public static Storyboard AnimateY(this FrameworkElement element, double y, double duration = 250, EasingFunctionBase easingFunction = null)
        {
            if (element.GetTranslateY() != y)
            {
                return AnimateDouble(element, "TranslateY", element.Width, y, duration, easingFunction);
            }
            return null;
        }
        public static async Task AnimateYAsync(this FrameworkElement element, double y, double duration = 250, EasingFunctionBase easingFunction = null)
        {
            if (element.GetTranslateY() != y)
            {
                await AnimateDoubleAsync(element, "TranslateY", element.Width, y, duration, easingFunction);
            }
        }

        public static Storyboard AnimateWidth(this FrameworkElement element, double width, double duration = 250, EasingFunctionBase easingFunction = null)
        {
            if (element.Width != width)
            {
                return AnimateDouble(element, "Width", element.Width, width, duration, easingFunction);
            }
            return null;
        }
        public static async Task AnimateWidthAsync(this FrameworkElement element, double width, double duration = 250, EasingFunctionBase easingFunction = null)
        {
            if (element.Width != width)
            {
                await AnimateDoubleAsync(element, "Width", element.Width, width, duration, easingFunction);
            }
        }

        public static Storyboard AnimateHeight(this FrameworkElement element, double height, double duration = 250, EasingFunctionBase easingFunction = null)
        {
            if (element.Height != height)
            {
                return AnimateDouble(element, "Height", element.Height, height, duration, easingFunction);
            }
            return null;
        }
        public static async Task AnimateHeightAsync(this FrameworkElement element, double height, double duration = 250, EasingFunctionBase easingFunction = null)
        {
            if (element.Height != height)
            {
                await AnimateDoubleAsync(element, "Height", element.Height, height, duration, easingFunction);
            }
        }

        public static Storyboard FadeIn(this FrameworkElement element, double duration = 250, EasingFunctionBase easingFunction = null)
        {
            if (element.Opacity < 1.0)
            {
                return AnimateDouble(element, "Opacity", element.Opacity, 1.0, duration, easingFunction);
            }
            return null;
        }
        public static async Task FadeInAsync(this FrameworkElement element, double duration = 250, EasingFunctionBase easingFunction = null)
        {
            if (element.Opacity < 1.0)
            {
                await AnimateDoubleAsync(element, "Opacity", element.Opacity, 1.0, duration, easingFunction);
            }
        }

        public static Storyboard FadeOut(this FrameworkElement element, double duration = 250, EasingFunctionBase easingFunction = null)
        {
            if (element.Opacity > 0.0)
            {
                return AnimateDouble(element, "Opacity", element.Opacity, 0.0, duration, easingFunction);
            }
            return null;
        }
        public static async Task FadeOutAsync(this FrameworkElement element, double duration = 250, EasingFunctionBase easingFunction = null)
        {
            if (element.Opacity > 0.0)
            {
                await AnimateDoubleAsync(element, "Opacity", element.Opacity, 0.0, duration, easingFunction);
            }
        }
        public static Task AnimateDoubleAsync(this FrameworkElement element, string property, double from, double to, double duration = 250, EasingFunctionBase easingFunction = null)
        {
            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>();
            Storyboard storyboard = element.AnimateDouble(property, from, to, duration, easingFunction);
            storyboard.Completed += (sender, e) =>
            {
                tcs.SetResult(true);
            };
            return tcs.Task;
        }
        public static Storyboard AnimateDouble(this FrameworkElement element, string property, double from, double to, double duration = 250, EasingFunctionBase easingFunction = null)
        {
            var storyboard = new Storyboard();
            var animation = new DoubleAnimation
            {
                From = from,
                To = to,
                Duration = TimeSpan.FromMilliseconds(duration),
                EasingFunction = easingFunction ?? new SineEase(),
                FillBehavior = FillBehavior.HoldEnd,
                EnableDependentAnimation = true
            };

            Storyboard.SetTarget(animation, element);
            Storyboard.SetTargetProperty(animation, property);

            storyboard.Children.Add(animation);
            storyboard.FillBehavior = FillBehavior.HoldEnd;
            storyboard.Begin();

            return storyboard;
        }
    }
}
