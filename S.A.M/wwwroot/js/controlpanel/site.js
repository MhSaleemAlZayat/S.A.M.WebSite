// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
// Translation object
        const translations = {
            en: {
                // Navigation
                sam_admin: "SAM Admin",
                control_panel: "Control Panel",
                main: "Main",
                dashboard: "Dashboard",
                content_management: "Content Management",
                media_library: "Media Library",
                user_management: "User Management",
                analytics: "Analytics",
                reports: "Reports",
                settings: "Settings",
                languages: "Languages",
                admin_user: "Admin User",
                administrator: "Administrator",
                
                // Header
                search: "Search...",
                notifications: "Notifications",
                mark_all_read: "Mark all read",
                clear_all: "Clear all",
                all: "All",
                unread: "Unread",
                view_all_notifications: "View All Notifications",
                online: "Online",
                
                // User Menu
                profile: "Profile",
                view_profile: "View Profile",
                view_profile_desc: "See your profile information",
                edit_profile: "Edit Profile",
                edit_profile_desc: "Update your information",
                change_password: "Change Password",
                change_password_desc: "Update your password",
                sign_out: "Sign Out",
                sign_out_desc: "Sign out of your account",
                
                // Dashboard
                total_articles: "Total Articles",
                total_users: "Total Users",
                page_views: "Page Views",
                media_files: "Media Files",
                increase_last_month: "+12% from last month",
                increase_last_month_8: "+8% from last month",
                decrease_last_month: "-3% from last month",
                increase_last_month_15: "+15% from last month",
                website_traffic: "Website Traffic",
                content_performance: "Content Performance",
                articles: "Articles",
                videos: "Videos",
                images: "Images",
                chart_placeholder: "Chart would be displayed here",
                recent_activity: "Recent Activity",
                article_published: 'New article published: "Democratic Reforms in Syria"',
                user_registered: "New user registered: Ahmed Al-Damasci",
                video_uploaded: 'Video uploaded: "Educational Initiatives 2024"',
                hours_ago_2: "2 hours ago",
                hours_ago_4: "4 hours ago",
                hours_ago_6: "6 hours ago",
                
                // Content Management
                add_new_article: "Add New Article",
                all_categories: "All Categories",
                politics: "Politics",
                education: "Education",
                economy: "Economy",
                international: "International",
                all_languages: "All Languages",
                arabic: "Arabic",
                english: "English",
                french: "French",
                all_status: "All Status",
                published: "Published",
                draft: "Draft",
                pending: "Pending",
                search_articles: "Search articles...",
                title: "Title",
                category: "Category",
                language: "Language",
                status: "Status",
                date: "Date",
                actions: "Actions",
                edit: "Edit",
                delete: "Delete",
                democratic_reforms_syria: "Democratic Reforms in Syria",
                comprehensive_plan: "Comprehensive plan for political transition...",
                educational_reform_initiative: "Educational Reform Initiative",
                new_programs_students: "New programs for Syrian students...",
                
                // Media Library
                upload_media: "Upload Media",
                
                // User Management
                add_new_user: "Add New User",
                user: "User",
                role: "Role",
                last_login: "Last Login",
                editor: "Editor",
                admin: "Admin",
                active: "Active",
                suspend: "Suspend",
                day_ago_1: "1 day ago",
                
                // Notifications
                system_update_available: "System Update Available",
                system_update_message: "A new system update is available for installation.",
                minutes_ago_2: "2 minutes ago",
                new_user_registration: "New User Registration",
                user_registered_message: "Ahmed Al-Damasci has registered for an account.",
                minutes_ago_15: "15 minutes ago",
                article_pending_review: "Article Pending Review",
                article_pending_message: '"Educational Reforms 2024" is waiting for approval.',
                hour_ago_1: "1 hour ago",
                security_alert: "Security Alert",
                security_alert_message: "Unusual login activity detected from new location.",
                hours_ago_3: "3 hours ago",
                new_comment: "New Comment",
                new_comment_message: 'Someone commented on "Democratic Reforms in Syria".',
                hours_ago_5: "5 hours ago",
                
                // Modals
                current_password: "Current Password",
                new_password: "New Password",
                confirm_new_password: "Confirm New Password",
                cancel: "Cancel",
                update_password: "Update Password",
                profile_information: "Profile Information",
                personal_information: "Personal Information",
                full_name: "Full Name",
                email: "Email",
                account_details: "Account Details",
                member_since: "Member Since",
                january_2024: "January 2024",
                today_230pm: "Today at 2:30 PM",
                close: "Close",
                confirm_logout: "Confirm Logout",
                logout_confirmation: "Are you sure you want to sign out?",
                logout_message: "You will need to sign in again to access the admin panel.",
                
                // Descriptions
                analytics_description: "Analytics dashboard with detailed metrics and reports will be displayed here.",
                reports_description: "Generate and view various reports about website performance and user activity.",
                language_management: "Language Management",
                language_management_description: "Manage multi-language content and translation settings.",
                settings_description: "Configure website settings, preferences, and system options."
            },
            ar: {
                // Navigation
                sam_admin: "إدارة الحركة الأكاديمية السورية",
                control_panel: "لوحة التحكم",
                main: "الرئيسية",
                dashboard: "لوحة المعلومات",
                content_management: "إدارة المحتوى",
                media_library: "مكتبة الوسائط",
                user_management: "إدارة المستخدمين",
                analytics: "التحليلات",
                reports: "التقارير",
                settings: "الإعدادات",
                languages: "اللغات",
                admin_user: "المستخدم الإداري",
                administrator: "مدير النظام",
                
                // Header
                search: "البحث...",
                notifications: "الإشعارات",
                mark_all_read: "تحديد الكل كمقروء",
                clear_all: "مسح الكل",
                all: "الكل",
                unread: "غير مقروء",
                view_all_notifications: "عرض جميع الإشعارات",
                online: "متصل",
                
                // User Menu
                profile: "الملف الشخصي",
                view_profile: "عرض الملف الشخصي",
                view_profile_desc: "عرض معلومات ملفك الشخصي",
                edit_profile: "تحرير الملف الشخصي",
                edit_profile_desc: "تحديث معلوماتك",
                change_password: "تغيير كلمة المرور",
                change_password_desc: "تحديث كلمة المرور",
                sign_out: "تسجيل الخروج",
                sign_out_desc: "تسجيل الخروج من حسابك",
                
                // Dashboard
                total_articles: "إجمالي المقالات",
                total_users: "إجمالي المستخدمين",
                page_views: "مشاهدات الصفحة",
                media_files: "ملفات الوسائط",
                increase_last_month: "+12% من الشهر الماضي",
                increase_last_month_8: "+8% من الشهر الماضي",
                decrease_last_month: "-3% من الشهر الماضي",
                increase_last_month_15: "+15% من الشهر الماضي",
                website_traffic: "حركة الموقع",
                content_performance: "أداء المحتوى",
                articles: "المقالات",
                videos: "الفيديوهات",
                images: "الصور",
                chart_placeholder: "سيتم عرض الرسم البياني هنا",
                recent_activity: "النشاط الأخير",
                article_published: 'تم نشر مقال جديد: "الإصلاحات الديمقراطية في سوريا"',
                user_registered: "تسجيل مستخدم جديد: أحمد الدمشقي",
                video_uploaded: 'تم رفع فيديو: "المبادرات التعليمية 2024"',
                hours_ago_2: "منذ ساعتين",
                hours_ago_4: "منذ 4 ساعات",
                hours_ago_6: "منذ 6 ساعات",
                
                // Content Management
                add_new_article: "إضافة مقال جديد",
                all_categories: "جميع الفئات",
                politics: "السياسة",
                education: "التعليم",
                economy: "الاقتصاد",
                international: "دولي",
                all_languages: "جميع اللغات",
                arabic: "العربية",
                english: "الإنجليزية",
                french: "الفرنسية",
                all_status: "جميع الحالات",
                published: "منشور",
                draft: "مسودة",
                pending: "في الانتظار",
                search_articles: "البحث في المقالات...",
                title: "العنوان",
                category: "الفئة",
                language: "اللغة",
                status: "الحالة",
                date: "التاريخ",
                actions: "الإجراءات",
                edit: "تحرير",
                delete: "حذف",
                democratic_reforms_syria: "الإصلاحات الديمقراطية في سوريا",
                comprehensive_plan: "خطة شاملة للانتقال السياسي...",
                educational_reform_initiative: "مبادرة الإصلاح التعليمي",
                new_programs_students: "برامج جديدة للطلاب السوريين...",
                
                // Media Library
                upload_media: "رفع وسائط",
                
                // User Management
                add_new_user: "إضافة مستخدم جديد",
                user: "المستخدم",
                role: "الدور",
                last_login: "آخر تسجيل دخول",
                editor: "محرر",
                admin: "مدير",
                active: "نشط",
                suspend: "تعليق",
                day_ago_1: "منذ يوم واحد",
                
                // Notifications
                system_update_available: "تحديث النظام متاح",
                system_update_message: "يتوفر تحديث جديد للنظام للتثبيت.",
                minutes_ago_2: "منذ دقيقتين",
                new_user_registration: "تسجيل مستخدم جديد",
                user_registered_message: "أحمد الدمشقي سجل حساباً جديداً.",
                minutes_ago_15: "منذ 15 دقيقة",
                article_pending_review: "مقال في انتظار المراجعة",
                article_pending_message: '"الإصلاحات التعليمية 2024" في انتظار الموافقة.',
                hour_ago_1: "منذ ساعة واحدة",
                security_alert: "تنبيه أمني",
                security_alert_message: "تم اكتشاف نشاط تسجيل دخول غير عادي من موقع جديد.",
                hours_ago_3: "منذ 3 ساعات",
                new_comment: "تعليق جديد",
                new_comment_message: 'شخص ما علق على "الإصلاحات الديمقراطية في سوريا".',
                hours_ago_5: "منذ 5 ساعات",
                
                // Modals
                current_password: "كلمة المرور الحالية",
                new_password: "كلمة المرور الجديدة",
                confirm_new_password: "تأكيد كلمة المرور الجديدة",
                cancel: "إلغاء",
                update_password: "تحديث كلمة المرور",
                profile_information: "معلومات الملف الشخصي",
                personal_information: "المعلومات الشخصية",
                full_name: "الاسم الكامل",
                email: "البريد الإلكتروني",
                account_details: "تفاصيل الحساب",
                member_since: "عضو منذ",
                january_2024: "يناير 2024",
                today_230pm: "اليوم في 2:30 مساءً",
                close: "إغلاق",
                confirm_logout: "تأكيد تسجيل الخروج",
                logout_confirmation: "هل أنت متأكد من أنك تريد تسجيل الخروج؟",
                logout_message: "ستحتاج إلى تسجيل الدخول مرة أخرى للوصول إلى لوحة الإدارة.",
                
                // Descriptions
                analytics_description: "ستعرض لوحة التحليلات مع المقاييس والتقارير التفصيلية هنا.",
                reports_description: "إنشاء وعرض تقارير مختلفة حول أداء الموقع ونشاط المستخدمين.",
                language_management: "إدارة اللغات",
                language_management_description: "إدارة المحتوى متعدد اللغات وإعدادات الترجمة.",
                settings_description: "تكوين إعدادات الموقع والتفضيلات وخيارات النظام."
            }
        };

        // Current language
        let currentLanguage = localStorage.getItem('language') || 'en';

        // Initialize all functionality when DOM is loaded
        document.addEventListener('DOMContentLoaded', function() {
            console.log('DOM loaded, initializing app...');
            initializeApp();
        });

        function initializeApp() {
            console.log('Initializing app components...');
            
            // Initialize all components
            initializeSidebar();
            initializeTheme();
            initializeNotifications();
            initializeUserDropdown();
            initializeLanguageSwitcher();
            initializeModals();
            
            // Apply saved language
            applyLanguage(currentLanguage);
            
            // Set initial mobile sidebar state
            if (window.innerWidth < 1024) {
                document.getElementById('sidebar').classList.add('-translate-x-full');
            }
            
            console.log('App initialization complete');
        }

        // Language Switcher
        function initializeLanguageSwitcher() {
            console.log('Initializing language switcher...');
            
            const languageBtn = document.getElementById('languageBtn');
            const languageDropdown = document.getElementById('languageDropdown');
            const languageOptions = document.querySelectorAll('.language-option');

            if (!languageBtn || !languageDropdown) {
                console.error('Language elements not found');
                return;
            }

            // Toggle language dropdown
            languageBtn.addEventListener('click', (e) => {
                console.log('Language button clicked');
                e.stopPropagation();
                languageDropdown.classList.toggle('show');
                // Close other dropdowns
                const notificationDropdown = document.getElementById('notificationDropdown');
                const userDropdown = document.getElementById('userDropdown');
                if (notificationDropdown) notificationDropdown.classList.remove('show');
                if (userDropdown) userDropdown.classList.remove('show');
            });

            // Language option selection
            languageOptions.forEach(option => {
                option.addEventListener('click', (e) => {
                    console.log('Language option clicked:', option.dataset.lang);
                    e.preventDefault();
                    const selectedLang = option.dataset.lang;
                    changeLanguage(selectedLang);
                    languageDropdown.classList.remove('show');
                });
            });

            // Close dropdown when clicking outside
            document.addEventListener('click', (e) => {
                if (!e.target.closest('#languageDropdown') && !e.target.closest('#languageBtn')) {
                    languageDropdown.classList.remove('show');
                }
            });
            
            console.log('Language switcher initialized');
        }

        function changeLanguage(lang) {
            console.log('Changing language to:', lang);
            currentLanguage = lang;
            localStorage.setItem('language', lang);
            applyLanguage(lang);
            showToast(lang === 'ar' ? 'تم تغيير اللغة بنجاح!' : 'Language changed successfully!');
        }

        function applyLanguage(lang) {
            console.log('Applying language:', lang);
            
            const html = document.documentElement;
            const currentLangElement = document.getElementById('currentLanguage');
            
            // Update language indicator
            if (currentLangElement) {
                currentLangElement.textContent = lang === 'ar' ? 'ع' : 'EN';
            }
            
            // Set HTML attributes for RTL/LTR
            if (lang === 'ar') {
                html.setAttribute('dir', 'rtl');
                html.setAttribute('lang', 'ar');
                html.classList.add('rtl');
            } else {
                html.setAttribute('dir', 'ltr');
                html.setAttribute('lang', 'en');
                html.classList.remove('rtl');
            }

            // Update all translatable elements
            const translatableElements = document.querySelectorAll('[data-translate]');
            translatableElements.forEach(element => {
                const key = element.getAttribute('data-translate');
                if (translations[lang] && translations[lang][key]) {
                    element.textContent = translations[lang][key];
                }
            });

            // Update placeholder texts
            const placeholderElements = document.querySelectorAll('[data-translate-placeholder]');
            placeholderElements.forEach(element => {
                const key = element.getAttribute('data-translate-placeholder');
                if (translations[lang] && translations[lang][key]) {
                    element.placeholder = translations[lang][key];
                }
            });

            // Update page title in navigation
            updatePageTitle();
            
            console.log('Language applied successfully');
        }

        function updatePageTitle() {
            const activeNavItem = document.querySelector('.nav-item.active');
            const pageTitle = document.getElementById('pageTitle');
            
            if (activeNavItem && pageTitle) {
                const sectionKey = activeNavItem.dataset.section;
                const titleKey = sectionKey === 'dashboard' ? 'dashboard' : 
                                sectionKey === 'content' ? 'content_management' :
                                sectionKey === 'media' ? 'media_library' :
                                sectionKey === 'users' ? 'user_management' :
                                sectionKey === 'analytics' ? 'analytics' :
                                sectionKey === 'reports' ? 'reports' :
                                sectionKey === 'languages' ? 'languages' :
                                sectionKey === 'settings' ? 'settings' : 'dashboard';
                
                if (translations[currentLanguage] && translations[currentLanguage][titleKey]) {
                    pageTitle.textContent = translations[currentLanguage][titleKey];
                }
            }
        }

        // Sidebar Navigation
        function initializeSidebar() {
            console.log('Initializing sidebar...');
            
            const navItems = document.querySelectorAll('.nav-item');
            const contentSections = document.querySelectorAll('.content-section');
            const sidebarToggle = document.getElementById('sidebarToggle');
            const sidebar = document.getElementById('sidebar');
            const sidebarOverlay = document.getElementById('sidebarOverlay');

            if (!navItems.length || !contentSections.length) {
                console.error('Sidebar elements not found');
                return;
            }

            // Navigation functionality
            navItems.forEach(item => {
                item.addEventListener('click', (e) => {
                    console.log('Nav item clicked:', item.dataset.section);
                    e.preventDefault();
                    
                    // Remove active class from all nav items
                    navItems.forEach(nav => nav.classList.remove('active'));
                    
                    // Add active class to clicked item
                    item.classList.add('active');
                    
                    // Hide all content sections
                    contentSections.forEach(section => section.classList.add('hidden'));
                    
                    // Show selected section
                    const sectionId = item.dataset.section + '-section';
                    const targetSection = document.getElementById(sectionId);
                    if (targetSection) {
                        targetSection.classList.remove('hidden');
                        targetSection.classList.add('fade-in');
                    }
                    
                    // Update page title
                    updatePageTitle();
                    
                    // Close mobile sidebar
                    if (window.innerWidth < 1024 && sidebar && sidebarOverlay) {
                        sidebar.classList.add('-translate-x-full');
                        sidebarOverlay.classList.add('hidden');
                    }
                });
            });

            // Mobile sidebar toggle
            if (sidebarToggle && sidebar && sidebarOverlay) {
                sidebarToggle.addEventListener('click', () => {
                    console.log('Sidebar toggle clicked');
                    sidebar.classList.toggle('-translate-x-full');
                    sidebarOverlay.classList.toggle('hidden');
                });

                sidebarOverlay.addEventListener('click', () => {
                    sidebar.classList.add('-translate-x-full');
                    sidebarOverlay.classList.add('hidden');
                });
            }

            // Handle window resize
            window.addEventListener('resize', () => {
                if (window.innerWidth >= 1024 && sidebar && sidebarOverlay) {
                    sidebar.classList.remove('-translate-x-full');
                    sidebarOverlay.classList.add('hidden');
                } else if (sidebar) {
                    sidebar.classList.add('-translate-x-full');
                }
            });
            
            console.log('Sidebar initialized');
        }

        // Theme Toggle
        function initializeTheme() {
            console.log('Initializing theme...');
            
            const themeToggle = document.getElementById('themeToggle');
            const html = document.documentElement;

            if (!themeToggle) {
                console.error('Theme toggle not found');
                return;
            }

            // Load saved theme
            const savedTheme = localStorage.getItem('theme');
            if (savedTheme === 'dark') {
                html.classList.add('dark');
            }

            themeToggle.addEventListener('click', () => {
                console.log('Theme toggle clicked');
                html.classList.toggle('dark');
                localStorage.setItem('theme', html.classList.contains('dark') ? 'dark' : 'light');
                const message = currentLanguage === 'ar' ? 'تم تحديث المظهر بنجاح!' : 'Theme updated successfully!';
                showToast(message);
            });
            
            console.log('Theme initialized');
        }

        // Notification System
        function initializeNotifications() {
            console.log('Initializing notifications...');
            
            const notificationBtn = document.getElementById('notificationBtn');
            const notificationDropdown = document.getElementById('notificationDropdown');
            const markAllRead = document.getElementById('markAllRead');
            const clearAll = document.getElementById('clearAll');

            if (!notificationBtn || !notificationDropdown) {
                console.error('Notification elements not found');
                return;
            }

            // Toggle notification dropdown
            notificationBtn.addEventListener('click', (e) => {
                console.log('Notification button clicked');
                e.stopPropagation();
                notificationDropdown.classList.toggle('show');
                // Close other dropdowns
                const userDropdown = document.getElementById('userDropdown');
                const languageDropdown = document.getElementById('languageDropdown');
                if (userDropdown) userDropdown.classList.remove('show');
                if (languageDropdown) languageDropdown.classList.remove('show');
            });

            // Tab switching
            document.querySelectorAll('.notification-tab').forEach(tab => {
                tab.addEventListener('click', () => {
                    console.log('Notification tab clicked:', tab.dataset.tab);
                    switchNotificationTab(tab.dataset.tab);
                });
            });

            // Mark all as read
            if (markAllRead) {
                markAllRead.addEventListener('click', () => {
                    console.log('Mark all read clicked');
                    markAllNotificationsAsRead();
                });
            }

            // Clear all notifications
            if (clearAll) {
                clearAll.addEventListener('click', () => {
                    console.log('Clear all clicked');
                    clearAllNotifications();
                });
            }

            // Individual notification actions
            document.addEventListener('click', (e) => {
                if (e.target.closest('.notification-item')) {
                    const item = e.target.closest('.notification-item');
                    if (e.target.closest('.notification-action')) {
                        e.stopPropagation();
                        removeNotification(item.dataset.id);
                    } else {
                        markNotificationAsRead(item.dataset.id);
                    }
                }
            });

            // Close dropdown when clicking outside
            document.addEventListener('click', (e) => {
                if (!e.target.closest('#notificationDropdown') && !e.target.closest('#notificationBtn')) {
                    notificationDropdown.classList.remove('show');
                }
            });

            // Initialize counts
            updateNotificationCounts();
            
            console.log('Notifications initialized');
        }

        function switchNotificationTab(tab) {
            // Update active tab
            document.querySelectorAll('.notification-tab').forEach(t => {
                t.classList.remove('active');
            });
            
            const activeTab = document.querySelector(`[data-tab="${tab}"]`);
            if (activeTab) {
                activeTab.classList.add('active');
            }

            // Filter notifications
            const notifications = document.querySelectorAll('.notification-item');
            notifications.forEach(notification => {
                if (tab === 'all') {
                    notification.style.display = 'block';
                } else if (tab === 'unread') {
                    notification.style.display = notification.dataset.read === 'false' ? 'block' : 'none';
                }
            });
        }

        function markNotificationAsRead(id) {
            const notification = document.querySelector(`[data-id="${id}"]`);
            if (notification && notification.dataset.read === 'false') {
                notification.dataset.read = 'true';
                notification.classList.remove('notification-unread');
                updateNotificationCounts();
                const message = currentLanguage === 'ar' ? 'تم تحديد الإشعار كمقروء' : 'Notification marked as read';
                showToast(message);
            }
        }

        function markAllNotificationsAsRead() {
            const unreadNotifications = document.querySelectorAll('[data-read="false"]');
            unreadNotifications.forEach(notification => {
                notification.dataset.read = 'true';
                notification.classList.remove('notification-unread');
            });
            updateNotificationCounts();
            const message = currentLanguage === 'ar' ? 'تم تحديد جميع الإشعارات كمقروءة' : 'All notifications marked as read';
            showToast(message);
        }

        function removeNotification(id) {
            const notification = document.querySelector(`[data-id="${id}"]`);
            if (notification) {
                notification.style.animation = 'slideOut 0.3s ease';
                setTimeout(() => {
                    notification.remove();
                    updateNotificationCounts();
                    const message = currentLanguage === 'ar' ? 'تم حذف الإشعار' : 'Notification removed';
                    showToast(message);
                }, 300);
            }
        }

        function clearAllNotifications() {
            const confirmMessage = currentLanguage === 'ar' ? 
                'هل أنت متأكد من أنك تريد مسح جميع الإشعارات؟' : 
                'Are you sure you want to clear all notifications?';
                
            if (confirm(confirmMessage)) {
                const notifications = document.querySelectorAll('.notification-item');
                notifications.forEach(notification => {
                    notification.style.animation = 'slideOut 0.3s ease';
                    setTimeout(() => notification.remove(), 300);
                });
                
                setTimeout(() => {
                    updateNotificationCounts();
                    const message = currentLanguage === 'ar' ? 'تم مسح جميع الإشعارات' : 'All notifications cleared';
                    showToast(message);
                }, 300);
            }
        }

        function updateNotificationCounts() {
            const allNotifications = document.querySelectorAll('.notification-item');
            const unreadNotifications = document.querySelectorAll('[data-read="false"]');
            
            const allCount = allNotifications.length;
            const unreadCount = unreadNotifications.length;

            const allCountElement = document.getElementById('allCount');
            const unreadCountElement = document.getElementById('unreadCount');
            
            if (allCountElement) allCountElement.textContent = allCount;
            if (unreadCountElement) unreadCountElement.textContent = unreadCount;
            
            const badge = document.getElementById('notificationBadge');
            if (badge) {
                if (unreadCount > 0) {
                    badge.textContent = unreadCount;
                    badge.style.display = 'flex';
                } else {
                    badge.style.display = 'none';
                }
            }
        }

        // User Dropdown
        function initializeUserDropdown() {
            console.log('Initializing user dropdown...');
            
            const userDropdownBtn = document.getElementById('userDropdownBtn');
            const userDropdown = document.getElementById('userDropdown');

            if (!userDropdownBtn || !userDropdown) {
                console.error('User dropdown elements not found');
                return;
            }

            // Toggle user dropdown
            userDropdownBtn.addEventListener('click', (e) => {
                console.log('User dropdown button clicked');
                e.stopPropagation();
                userDropdown.classList.toggle('show');
                // Close other dropdowns
                const notificationDropdown = document.getElementById('notificationDropdown');
                const languageDropdown = document.getElementById('languageDropdown');
                if (notificationDropdown) notificationDropdown.classList.remove('show');
                if (languageDropdown) languageDropdown.classList.remove('show');
            });

            // Close dropdown when clicking outside
            document.addEventListener('click', (e) => {
                if (!e.target.closest('#userDropdown') && !e.target.closest('#userDropdownBtn')) {
                    userDropdown.classList.remove('show');
                }
            });
            
            console.log('User dropdown initialized');
        }

        // Modal Functions
        function initializeModals() {
            console.log('Initializing modals...');
            
            // Close modals when clicking outside
            document.addEventListener('click', (e) => {
                if (e.target.classList.contains('modal')) {
                    const modalId = e.target.id;
                    closeModal(modalId);
                }
            });

            // Handle form submissions
            document.addEventListener('submit', (e) => {
                e.preventDefault();
                if (e.target.closest('#changePasswordModal')) {
                    const message = currentLanguage === 'ar' ? 'تم تحديث كلمة المرور بنجاح!' : 'Password updated successfully!';
                    showToast(message);
                    closeModal('changePasswordModal');
                }
            });
            
            console.log('Modals initialized');
        }

        function openModal(modalId) {
            const modal = document.getElementById(modalId);
            if (modal) {
                modal.classList.remove('hidden');
                document.body.style.overflow = 'hidden';
            }
        }

        function closeModal(modalId) {
            const modal = document.getElementById(modalId);
            if (modal) {
                modal.classList.add('hidden');
                document.body.style.overflow = 'auto';
            }
        }

        function openProfileModal() {
            openModal('profileModal');
            const userDropdown = document.getElementById('userDropdown');
            if (userDropdown) userDropdown.classList.remove('show');
        }

        function openEditProfileModal() {
            const title = currentLanguage === 'ar' ? 'تحرير الملف الشخصي' : 'Edit Profile';
            const content = currentLanguage === 'ar' ? 
                'سيتم تنفيذ وظيفة تحرير الملف الشخصي هنا مع نموذج شامل لتحديث معلومات المستخدم.' :
                'Edit profile functionality would be implemented here with a comprehensive form for updating user information.';
            showGenericModal(title, content);
            const userDropdown = document.getElementById('userDropdown');
            if (userDropdown) userDropdown.classList.remove('show');
        }

        function openChangePasswordModal() {
            openModal('changePasswordModal');
            const userDropdown = document.getElementById('userDropdown');
            if (userDropdown) userDropdown.classList.remove('show');
        }

        function showGenericModal(title, content) {
            const titleElement = document.getElementById('genericModalTitle');
            const contentElement = document.getElementById('genericModalContent');
            
            if (titleElement) titleElement.textContent = title;
            if (contentElement) contentElement.textContent = content;
            
            openModal('genericModal');
        }

        function confirmLogout() {
            openModal('logoutModal');
            const userDropdown = document.getElementById('userDropdown');
            if (userDropdown) userDropdown.classList.remove('show');
        }

        function performLogout() {
            closeModal('logoutModal');
            const signingOutMessage = currentLanguage === 'ar' ? 'جاري تسجيل الخروج...' : 'Signing out...';
            showToast(signingOutMessage, 'info');
            
            // Simulate logout process
            setTimeout(() => {
                const successMessage = currentLanguage === 'ar' ? 'تم تسجيل الخروج بنجاح' : 'You have been signed out successfully';
                showToast(successMessage, 'success');
                // In a real application, you would redirect to login page
                // window.location.href = '/login';
            }, 1000);
        }

        // Toast Notification System
        function showToast(message, type = 'success') {
            const notification = document.getElementById('notification');
            if (!notification) return;
            
            const icon = notification.querySelector('i');
            const text = notification.querySelector('span');
            
            if (text) text.textContent = message;
            
            // Update styling based on type
            notification.className = `fixed top-4 right-4 rtl:right-auto rtl:left-4 px-6 py-3 rounded-lg shadow-lg notification z-50`;
            if (type === 'success') {
                notification.classList.add('bg-green-500', 'text-white');
                if (icon) icon.className = 'fas fa-check-circle mr-2 rtl:mr-0 rtl:ml-2';
            } else if (type === 'error') {
                notification.classList.add('bg-red-500', 'text-white');
                if (icon) icon.className = 'fas fa-exclamation-circle mr-2 rtl:mr-0 rtl:ml-2';
            } else if (type === 'info') {
                notification.classList.add('bg-blue-500', 'text-white');
                if (icon) icon.className = 'fas fa-info-circle mr-2 rtl:mr-0 rtl:ml-2';
            }
            
            notification.classList.remove('hidden');
            
            setTimeout(() => {
                notification.classList.add('hidden');
            }, 3000);
        }