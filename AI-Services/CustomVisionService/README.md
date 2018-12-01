# Microsoft - AI School

Repository for **Microsoft AI School** program

* URL to program: <https://aischool.microsoft.com/en-us/home>

## AI House: AI Services

* **Link:** <https://aischool.microsoft.com/en-us/services/learning-paths>
* **Folder:** AI-Services
* **Description:** AI Services allow pre-built AI services to be easily infused into existing apps, without having to worry about the underlying ML model – all the hard work is done for you. Whether you’re adding facial recognition or sentiment analysis or any of our other 30+ AI services to your app, these learning paths will guide you through how to weave these features into your apps quickly.

### Learning Path: Custom Vision Service

* **Link:** <https://aischool.microsoft.com/en-us/services/learning-paths/custom-vision-service>

**1. Lab - Introduction to Custom Vision Service**

* **Link:** <https://github.com/Microsoft/ai-school-custom-vision-service-intro/blob/master/README.md>
* **Folder:** AI-Services/CustomVisionService/1-IntroCustomVisionService
* **Description:** This lab will show you how to bring advanced ML vision capabilities to your applications with the Custom Vision Service. The service makes it easy to build custom image classifiers and provides APIs and tools to help you improve your classifier over time. The lab is split in two parts: first, we'll show you how to use the Custom Vision portal to build a classifier and then we'll show you how to do the same thing using the SDK. In both cases, we'll be building a classifier that can distinguish between a Surface Pro and a Surface Studio.

**2. Lab - Exporting a Custom Vision model and deploy it to an Android device**

* **Link:** <https://aischool.microsoft.com/en-us/services/learning-paths/custom-vision-service/exporting-a-custom-vision-model-android>
* **Folder:** AI-Services/CustomVisionService/2-AndroidCustomVision
* **Description:** This tutorial will walk through how to export a Custom Vision model from the Custom Vision Service and deploying it to run on an Android device.
* **Notes:** The Microsoft tutorial is developed with an Android Native (Java) app. Instead of this, I built a Xamarin.Android app to consume the generated TensorFlow model because I have a personal interest on develop Xamarin apps. **The TensorFlow model is to recognize images between Surface Pro or Studio**. The links used to develop the Xamarin implementarion are:
  * [Custom Vision – Machine Learning Made Easy with Jim Bennett](https://channel9.msdn.com/Shows/XamarinShow/Custom-Vision--Machine-Learning-Made-Easy-with-Jim-Bennett).
  * [Using TensorFlow and Azure to Add Image Classification to Your Android Apps](https://blog.xamarin.com/android-apps-tensorflow/).

---

**Credits to Microsoft AI School Program on <https://aischool.microsoft.com/en-us/home>**